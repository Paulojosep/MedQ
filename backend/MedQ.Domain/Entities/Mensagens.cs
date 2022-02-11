using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Mensagens : Entity
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Viewd { get; set; }

        public int SocioId { get; set; }
        public Socio Socio { get; set; }
    }
}
