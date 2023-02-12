using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.IO
{
    public class FilaByTipoAtendimentoOutput
    {
        public int ID { get; set; }
        public int QtdPessoas { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TipoAntendimentoId { get; set; }
        public int EstabelecimentoId { get; set; }
        public int EspecialidadeId { get; set; }
        public string EspecialidadeNome { get; set; }
        public string EspecialidadeDescricao { get; set; }
    }
}
