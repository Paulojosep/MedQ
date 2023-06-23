using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Estabelecimento : Entity
    {
        public Estabelecimento()
        {
            Filas = new HashSet<Fila>();
            Telefones = new HashSet<Telefone>();
            Consultas = new HashSet<Consultas>();
            Medicos = new HashSet<Medico>();
            Calendarios = new HashSet<Calendario>();
            AgendamentoDisponiveis = new HashSet<AgendamentoDisponiveis>();
        }

        public Estabelecimento(int id, string nome, string cEP, string endereco, string complemento, string cidade, 
            string bairro, string estado, DateTime data_Cadastro, string image, int tipoEstabelecimentoId, int socioId)
        {
            Id = id;
            Nome = nome;
            CEP = cEP;
            Endereco = endereco;
            Complemento = complemento;
            Cidade = cidade;
            Bairro = bairro;
            Estado = estado;
            Data_Cadastro = data_Cadastro;
            Image = image;
            TipoEstabelecimentoId = tipoEstabelecimentoId;
            SocioId = socioId;
        }

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

        public virtual Socio Socio { get; set; }
        public virtual TipoEstabelecimento TipoEstbelecimento { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Calendario> Calendarios { get; set; }
        public virtual ICollection<AgendamentoDisponiveis> AgendamentoDisponiveis { get; set; }
        //public ICollection<Estabelecimento> Estabelecimentos { get; set; }
        //public ICollection<Socio> Socios { get; set; }
        //public ICollection<TipoEstabelecimento> TipoEstabelecimentos { get; set; }
    }
}
