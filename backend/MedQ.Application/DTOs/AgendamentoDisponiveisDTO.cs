using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class AgendamentoDisponiveisDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Disponibilidade { get; set; }
        public int MedicoId { get; set; }
        public int EstabelecimentoId { get; set; }

        //public virtual MedicoDTO Medico { get; set; }
        //public virtual EstabelecimentoDTO Estabelecmento { get; set; }

        //public virtual ICollection<ConsultasDTO> Consultas { get; set; }
    }
}
