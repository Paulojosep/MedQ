using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.IO
{
    public class ConsultasPorSocioOutput
    {
        public string Medico { get; set; }
        public string Especialidade { get; set; }
        public string Consultas { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }
    }
}
