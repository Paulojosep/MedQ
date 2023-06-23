using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedQ.Teste.Entities
{
    public class AgendamentoDisponiveisTeste
    {
        [Fact(DisplayName = "Adicionar Agendamento Disponivel")]
        public void AdicionarAgendamentoDisponivel()
        {
            // Act
            Action action = () => new AgendamentoDisponiveis(1, 1, 1, 1, DateTime.Now, DateTime.Now);
            
        }
    }
}
