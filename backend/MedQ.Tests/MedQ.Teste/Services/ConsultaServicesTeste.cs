using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.Services;
using MedQ.Domain.Entities;
using MedQ.Teste.Comum;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Teste.Services
{
    public class ConsultaServicesTeste : TesteBase
    {
        private Mock<IConsultaService> consultarServiceMock;

        public ConsultaServicesTeste()
        {
            // Assent
            consultarServiceMock = new Mock<IConsultaService>();
        }

        [Fact(DisplayName = "Listar Consultas Teste" )]
        public void ListarConsultasTest()
        {
            // Act
            var listaConsulta = consultarServiceMock.Setup(x => x.GetBySocioAsync(100));
            // Assert
            Console.WriteLine(listaConsulta.ToString());
            Assert.NotNull(listaConsulta);
        }

        [Fact(DisplayName = "Consultar Por ID")]
        public void ConsultarPorId()
        {
            // Act
            var consulta = consultarServiceMock.Setup(x => x.GetByIdAsync(1));

            // Assert
            Assert.NotNull(consulta);
        }

        [Fact(DisplayName = "Criar Consulta")]
        public void CriarConsulta()
        {
            bool resultado = false;
            var adicionarConsulta = new ConsultasDTO(200, 1, 1, 1, "12345", "1", DateTime.Now, DateTime.Now);
            consultarServiceMock.Setup(cons => cons.CreateAsync(adicionarConsulta).Result).Returns(resultado);

            // Assert
            Assert.True(resultado);
        }
    }
}
