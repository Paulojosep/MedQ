using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.IO
{
    public class ConsultasPorSocioOutput
    {
        public int Codigo { get; set; }
        public string Medico { get; set; }
        public string Especialidade { get; set; }
        public string Consultas { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }
    }
}
