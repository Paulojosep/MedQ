using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class EstabelecimentoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Image { get; set; }

        public int TipoEstabelecimentoId { get; set; }
        [JsonIgnore]
        public TipoEstabelecimentoDTO TipoEstbelecimento { get; set; }

        public int SocioId { get; set; }
        [JsonIgnore]
        public SocioDTO Socio { get; set; }

        public ICollection<FilaDTO> Filas { get; private set; }
        public ICollection<TelefoneDTO> Telefones { get; private set; }
        public ICollection<ConsultasDTO> Consultas { get; private set; }
        public ICollection<MedicoDTO> Medicos { get; private set; }
        public ICollection<CalendarioDTO> Calendarios { get; private set; }
        public ICollection<AgendamentoDisponiveisDTO> AgendamentoDisponiveis { get; private set; }
        //public ICollection<EstabelecimentoDTO> Estabelecimentos { get; private set; }
    }
}
