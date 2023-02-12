using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Telefone : Entity
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
        public int EstabelecimentoId { get; set; }
        public int SocioId { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
