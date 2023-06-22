using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.IoC.Results
{
    public class JsonResponse<T>
    {
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
