using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Runtime.InteropServices;
using MedQ.Application.Results;
using MedQ.Application.Exceptions;
using static System.Net.Mime.MediaTypeNames;

namespace MedQ.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly RestClient _client;
        private readonly string url;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            _client = new RestClient(_configuration.GetSection("Api").GetSection("EmailService").Value);
            this.url = _configuration.GetSection("Api").GetSection("EmailService").Value;
        }

        public async Task<EmailDTO> SendEmail(EmailDTO email)
        {
            var request = new RestRequest($"{this.url}/sending-email");
            request.AddJsonBody(new { ownerRef = email.ownerRef, emailFrom = email.emailFrom, emailTo = email.emailTo, subject = email.subject, text = email.text });
            return await PostAsync<EmailDTO>(request);
        }

        private async Task<T> PostAsync<T>(RestRequest request)
        {
            var response = await _client.PostAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                var error = JsonConvert.DeserializeObject<JsonResponse<object>>(response.Content);
                throw new MedQException(error.Message);
            }
        }
    }
}
