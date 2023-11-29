using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Results
{
    internal class JsonResponse<T>
    {
        public JsonResponse(T itemResponse) : this()
        {
            this.Data = itemResponse;
        }

        public JsonResponse()
        {
            this.CodeResponse = JsonMessageCode.Success;
        }

        public JsonMessageCode CodeResponse { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }

    public enum JsonMessageCode
    {
        Success = 1
        , Error = 2
        , UnknowError = 3
        , SesssaoExpirada = 4
    }
}
