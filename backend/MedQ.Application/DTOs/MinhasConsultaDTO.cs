using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class MinhasConsultaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Texto { get; set; }
        public string Pedido { get; set; }
        public string Senha { get; set; }
        public string Profissional { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Finished { get; set; }

        public int ConsultaId { get; set; }
        [JsonIgnore]
        public ConsultasDTO Consulta { get; set; }

        public int SocioId { get; set; }
        [JsonIgnore]
        public SocioDTO Socio { get; set; }
    }
}
