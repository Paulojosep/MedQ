using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class MinhasConsultas2
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

        public virtual Consultas consultas { get; set; }
        public virtual AgendamentoDisponiveis Agendamento { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual Especialidade Especialidade { get; set; }
        public virtual Medico Medico { get; set; }
    }
}
