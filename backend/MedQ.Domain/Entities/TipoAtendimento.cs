using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class TipoAtendimento : Entity
    {
        public string Tipo { get; set; }

        public ICollection<Fila> Filas { get; set; }
    }
}
