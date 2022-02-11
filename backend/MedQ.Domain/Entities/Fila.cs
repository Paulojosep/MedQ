using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Fila : Entity
    {
        public int QtdPessoas { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }

        public int TipoAntendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }

        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
