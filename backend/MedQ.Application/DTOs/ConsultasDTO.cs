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
        public AgendamentoDisponiveisDTO Agendamento { get; set; }

        public int EstabelecimentoId { get; set; }
        [JsonIgnore]
        public EstabelecimentoDTO Estabelecimento { get; set; }

        public int SocioId { get; set; }
        [JsonIgnore]
        public SocioDTO Socio { get; set; }

        public ICollection<MinhasConsultaDTO> MinhasConsultas { get; set; }
    }
}
