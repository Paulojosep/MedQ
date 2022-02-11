using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class TipoEstabelecimento : Entity
    {
        public string Tipo { get; set; }

        public ICollection<Estabelecimento> Estabelecimentos { get; private set; }
    }
}
