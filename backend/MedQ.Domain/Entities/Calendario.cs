using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Calendario : Entity
    {
        public string Dia { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int EstabelecimentoId { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}
