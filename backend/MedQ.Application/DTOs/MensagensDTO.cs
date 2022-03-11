using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class MensagensDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Viewd { get; set; }

        public int SocioId { get; set; }
        [JsonIgnore]
        public SocioDTO Socio { get; set; }
    }
}
