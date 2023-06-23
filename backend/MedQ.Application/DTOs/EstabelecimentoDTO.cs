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
        public int SocioId { get; set; }

        public virtual TipoEstabelecimentoDTO TipoEstbelecimento { get; set; }
        public virtual SocioDTO Socio { get; set; }

        //public virtual ICollection<FilaDTO> Filas { get; set; }
        //public virtual ICollection<TelefoneDTO> Telefones { get; set; }
        //public virtual ICollection<ConsultasDTO> Consultas { get; set; }
        //public virtual ICollection<MedicoDTO> Medicos { get; set; }
        //public virtual ICollection<CalendarioDTO> Calendarios { get; set; }
        //public virtual ICollection<AgendamentoDisponiveisDTO> AgendamentoDisponiveis { get; set; }
        //public virtual ICollection<EstabelecimentoDTO> Estabelecimentos { get; set; }
    }
}
