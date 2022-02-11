using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Socio : Entity
    {
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
        public long Image { get; set; }
        public string CodigoVerificacao { get; set; }
        public string IdGoogle { get; set; }
        public string Tipo { get; set; }
        

        public ICollection<Estabelecimento> Estabelecimentos { get; private set; }
        public ICollection<Consultas> Consultas { get; private set; }
        public ICollection<Mensagens> Mensagens { get; private set; }
        public ICollection<MinhasConsulta> MinhasConsultas { get; private set; }
        public ICollection<Telefone> Telefones { get; private set; }
    }
}
