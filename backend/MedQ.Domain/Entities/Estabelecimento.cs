using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Estabelecimento : Entity
    {
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public int Status { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public long Image { get; set; }

        public int TipoEstabelecimentoId { get; set; }
        public TipoEstabelecimento TipoEstbelecimento { get; set; }

        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        public ICollection<Fila> Filas { get; private set; }
        public ICollection<Telefone> Telefones { get; private set; }
        public ICollection<Consultas> Consultas { get; private set; }
        public ICollection<Medico> Medicos { get; private set; }
        public ICollection<Calendario> Calendarios { get; private set; }
        public ICollection<AgendamentoDisponiveis> AgendamentoDisponiveis { get; private set; }
        public ICollection<Estabelecimento> Estabelecimentos { get; private set; }
        public ICollection<Socio> Socios { get; private set; }
        public ICollection<TipoEstabelecimento> TipoEstabelecimentos { get; private set; }
    }
}
