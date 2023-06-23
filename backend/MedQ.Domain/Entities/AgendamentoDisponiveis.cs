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

        public AgendamentoDisponiveis(int id, int medicoId, int estabelecimentoId, int disponibilidade, DateTime data, DateTime hora)
        {
            Id = id;
            MedicoId = medicoId;
            EstabelecimentoId = estabelecimentoId;
            Disponibilidade = disponibilidade;
            Data = data;
            Hora = hora;
            
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
