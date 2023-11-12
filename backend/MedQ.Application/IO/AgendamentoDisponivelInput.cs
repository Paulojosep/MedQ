using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.IO
{
    public class AgendamentoDisponivelInput
    {
        public int? EstabelecimentoId { get; set; }
        public int? EspecialidadeId { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFim { get; set; }
    }

    public class AgendamentoDisponivelAtualizacaoDisponibilidadeInput
    {
        public int Id { get; set; }
        public int Disponibilidade { get; set; }
    }
}
