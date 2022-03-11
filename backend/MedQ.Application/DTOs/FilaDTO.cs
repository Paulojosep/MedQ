using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class FilaDTO
    {
        public int Id { get; set; }
        public int QtdPessoas { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TipoAntendimentoId { get; set; }

        [JsonIgnore]
        public TipoAtendimentoDTO TipoAtendimento { get; set; }
        public int EstabelecimentoId { get; set; }

        [JsonIgnore]
        public EstabelecimentoDTO Estabelecimento { get; set; }
        public int EspecialidadeId { get; set; }

        [JsonIgnore]
        public EspecialidadeDTO Especialidade { get; set; }
    }
}
