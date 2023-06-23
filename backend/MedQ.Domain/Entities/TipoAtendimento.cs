using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class TipoAtendimento : Entity
    {
        public TipoAtendimento()
        {
            Filas = new HashSet<Fila>();
        }

        public TipoAtendimento(int id, string tipo)
        {
            Id = id;
            Tipo = tipo;
        }

        public string Tipo { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
    }
}
