using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class AgendamentoDisponiveis : Entity
    {
        public DateTime DataHora { get; set; }
        public int Disponibilidade { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecmento { get; set; }
    }
}
