using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedQ.Domain.Entities
{
    public class AgendamentoDisponiveis : Entity
    {
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Disponibilidade { get; set; }

        [Column("fk_medico_id")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        [Column("fk_estabelecimento_id")]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecmento { get; set; }

        public ICollection<Consultas> Consultas { get; private set; }
    }
}
