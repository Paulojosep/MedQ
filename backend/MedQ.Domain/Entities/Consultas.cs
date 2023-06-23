using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedQ.Domain.Entities
{
    public class Consultas : Entity
    {
        public Consultas()
        {
            MinhasConsultas = new HashSet<MinhasConsulta>();
        }

        public Consultas(int id, int agendamentoId, int estabelecimentoId, int socioId, string senha, string status, DateTime data, DateTime hora)
        {
            Id = id;
            AgendamentoId = agendamentoId;
            EstabelecimentoId = estabelecimentoId;
            SocioId = socioId;
            Senha = senha;
            Status = status;
            Data = data;
            Hora = hora;
        }

        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }
        public int AgendamentoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual AgendamentoDisponiveis Agendamento { get; set; }

        public virtual ICollection<MinhasConsulta> MinhasConsultas { get; private set; }
    }
}
