using System;
using System.Collections.Generic;

namespace MedQ.Domain.Entities
{
    public class AgendamentoDisponiveis : Entity
    {
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Disponibilidade { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecmento { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
