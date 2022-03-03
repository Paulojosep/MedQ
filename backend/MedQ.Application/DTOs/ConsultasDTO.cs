using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class ConsultasDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }

        public int AgendamentoId { get; set; }
        [JsonIgnore]
        public AgendamentoDisponiveis Agendamento { get; set; }

        public int EstabelecimentoId { get; set; }
        [JsonIgnore]
        public Estabelecimento Estabelecimento { get; set; }

        public int SocioId { get; set; }
        [JsonIgnore]
        public Socio Socio { get; set; }
    }
}
