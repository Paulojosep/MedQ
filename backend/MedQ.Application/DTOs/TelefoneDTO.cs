using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class TelefoneDTO
    {
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public int EstabelecimentoId { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelecimento { get; set; }
        public int SocioId { get; set; }
        [JsonIgnore]
        public Socio Socio { get; set; }
    }
}
