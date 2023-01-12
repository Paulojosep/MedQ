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
        public int TipoAntendimentoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public int EspecialidadeId { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual TipoAtendimento TipoAtendimento { get; set; }
        public virtual Especialidade Especialidade { get; set; }
    }
}
