using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MedQ.Application.DTOs
{
    public class ConsultasDTO
    {
        public ConsultasDTO()
        {
            
        }

        public ConsultasDTO(int id, int agendamentoId, int estabelecimentoId, int socioId, string senha, string status, DateTime data, DateTime hora)
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

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Senha { get; set; }
        public int AgendamentoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public int SocioId { get; set; }

        public virtual SocioDTO Socio { get; set; }
        public virtual AgendamentoDisponiveisDTO Agendamento { get; set; }
        public virtual EstabelecimentoDTO Estabelecimento { get; set; }
    }
}
