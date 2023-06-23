using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Socio : Entity
    {
        public Socio()
        {
            Estabelecimentos = new HashSet<Estabelecimento>();
            Consultas = new HashSet<Consultas>();
            Mensagens = new HashSet<Mensagens>();
            MinhasConsultas = new HashSet<MinhasConsulta>();
            Telefones = new HashSet<Telefone>();
        }

        public Socio(int id, string nome, string cPF, string sexo, string email, string senha, string endereco, 
            string complemento, string cidade, string bairro, string uF, DateTime data_Cadastro, 
            string image, string codigoVerificacao, string idGoogle, string tipo)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            UF = uF;
            Sexo = sexo;
            Email = email;
            Senha = senha;
            Endereco = endereco;
            Complemento = complemento;
            Cidade = cidade;
            Bairro = bairro;
            Data_Cadastro = data_Cadastro;
            Image = image;
            CodigoVerificacao = codigoVerificacao;
            IdGoogle = idGoogle;
            Tipo = tipo;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Image { get; set; }
        public string CodigoVerificacao { get; set; }
        public string IdGoogle { get; set; }
        public string Tipo { get; set; }
        

        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
        public virtual ICollection<Mensagens> Mensagens { get; set; }
        public virtual ICollection<MinhasConsulta> MinhasConsultas { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
