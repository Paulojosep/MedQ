using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class TipoEstabelecimento : Entity
    {
        public TipoEstabelecimento()
        {
            Estabelecimentos = new HashSet<Estabelecimento>();
        }

        public string Tipo { get; set; }

        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; }
    }
}
