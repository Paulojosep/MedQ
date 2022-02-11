using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Medico : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}
