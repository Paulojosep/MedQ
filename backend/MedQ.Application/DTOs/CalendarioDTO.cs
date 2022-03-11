using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class CalendarioDTO
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int EstabelecimentoId { get; set; }
        [JsonIgnore]
        public EstabelecimentoDTO Estabelecimento { get; set; }
    }
}
