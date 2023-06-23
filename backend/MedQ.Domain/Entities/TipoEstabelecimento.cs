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

        public TipoEstabelecimento(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public string Tipo { get; set; }

        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; }
    }
}
