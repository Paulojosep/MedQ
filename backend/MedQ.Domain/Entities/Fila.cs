using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Fila : Entity
    {
        public int QtdPessoas { get; set; }
        public string Status { get; set; }
        public DateTime DataCadastro { get; set; }

        [Column("fk_tipo_atendimento_id")]
        public int TipoAntendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }

        [Column("fk_estabelecimento_id")]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }

        [Column("fk_especialidade_id")]
        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
