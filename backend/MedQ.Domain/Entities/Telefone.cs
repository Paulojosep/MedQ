using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Telefone : Entity
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public int SocioId { get; set; }
        public Socio Socio { get; set; }
    }
}
