using MedQ.Application.Exceptions;
using MedQ.Domain.Entities;
using MedQ.Infra.IoC.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedQ.Infra.IoC.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                JsonResponse<object> content = new JsonResponse<object>();
                //var erroInfo = await this.Translate(context, error);

                if (error.GetType() == typeof(MedQException))
                    content.CodeResponse = JsonMessageCode.Error;
                else //Gravar log de unknow <===============================================
                    content.CodeResponse = JsonMessageCode.UnknowError;

                if (error.InnerException != null)
                {
                    if (error.InnerException.Message.Contains("ORA-02292"))
                    {
                        content.Message = "Houve um erro na tentativa de exclusão do usuário. Existem vínculos em banco para o usuário que está se tentando excluir.";
                    }
                    else content.Message = error.InnerException.Message;
                }
                else content.Message = error.Message;

                var response = context.Response;
                response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(content, typeof(JsonResponse<object>), new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                await response.WriteAsync(result);
            }
        }
    }
}

