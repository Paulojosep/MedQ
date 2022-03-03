using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Medico : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        [Column("fk_especialidade_id")]
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }

        [Column("fk_estabelecimento_id")]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        public ICollection<AgendamentoDisponiveis> AgendamentoDisponiveis { get; private set; }
    }
}
