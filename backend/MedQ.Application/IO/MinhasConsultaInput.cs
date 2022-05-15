using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.IO
{
    public class MinhasConsultaInput
    {
        public string senha { get; set; }
        public string profissional_nome { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
        public string status { get; set; }
        public int consulta_id { get; set; }
        public int socio_id { get; set; }
        public string estabelecimento_nome { get; set; }
        public string especialidade_nome { get; set; }
        public string Pedido { get; set; }
        public Consultas consultas { get; set; }
        public AgendamentoDisponiveis Agendamento { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public Especialidade Especialidade { get; set; }
        public Medico Medico { get; set; }
    }
}
