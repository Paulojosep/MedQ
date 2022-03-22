using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedQ.Domain.Entities
{
    public class Consultas : Entity
    {
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }

        [Column("fk_agendamento_id")]
        public int AgendamentoId { get; set; }
        public AgendamentoDisponiveis Agendamento { get; set; }

        [Column("fk_estabelecimento_id")]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        [Column("fk_socio_id")]
        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        public ICollection<MinhasConsulta> MinhasConsultas { get; private set; }
    }
}
