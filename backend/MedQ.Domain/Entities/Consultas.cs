using System;
using System.Collections.Generic;

namespace MedQ.Domain.Entities
{
    public class Consultas : Entity
    {
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }

        public int AgendamentoId { get; set; }
        public AgendamentoDisponiveis Agendamento { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        public ICollection<MinhasConsulta> MinhasConsultas { get; set; }
    }
}
