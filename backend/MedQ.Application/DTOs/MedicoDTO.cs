using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public int EspecialidadeId { get; set; }
        [JsonIgnore]
        public EspecialidadeDTO Especialidade { get; set; }

        public int EstabelecimentoId { get; set; }
        [JsonIgnore]
        public EstabelecimentoDTO Estabelecimento { get; set; }

        public ICollection<AgendamentoDisponiveisDTO> AgendamentoDisponiveis { get; private set; }
    }
}
