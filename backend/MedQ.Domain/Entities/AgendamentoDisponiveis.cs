using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedQ.Domain.Entities
{
    public class AgendamentoDisponiveis : Entity
    {
        public AgendamentoDisponiveis()
        {
            Consultas = new HashSet<Consultas>();
        }

        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Disponibilidade { get; set; }
        public int MedicoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public virtual Estabelecimento Estabelecmento { get; set; }
        public virtual Medico Medico { get; set; }

        public virtual ICollection<Consultas> Consultas { get; set; }
    }
}
