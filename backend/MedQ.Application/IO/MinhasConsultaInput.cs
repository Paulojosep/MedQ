using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.IO
{
    public class MinhasConsultaInput
    {
        public string Senha { get; set; }
        public string ProfissionalNome { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int ConsultaId { get; set; }
        public int SocioId { get; set; }
        public string EstabelecimentoNome { get; set; }
        public string EspecialidadeNome { get; set; }
        public string Pedido { get; set; }
        public Consultas Consultas { get; set; }
        public AgendamentoDisponiveis Agendamento { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public Especialidade Especialidade { get; set; }
        public Medico Medico { get; set; }
    }
}
