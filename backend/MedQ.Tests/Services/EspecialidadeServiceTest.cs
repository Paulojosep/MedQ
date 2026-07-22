using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedQ.Tests.Services
{
    public class EspecialidadeServiceTest
    {
        private readonly Mock<IEspecialidadeService> _especialidadeServMock = new Mock<IEspecialidadeService>();

        [Fact(DisplayName = "Consulta Todas Especialidade Teve Retorna Todas")]
        public async Task GetAllAsync()
        {
            // Arrange
            var resultadoEsperado = new List<EspecialidadeDTO>()
            {
                new EspecialidadeDTO { Id = 1, Nome = "Ortopedia" }
            };

            _especialidadeServMock.Setup(setup => setup.GetAllAsync()).ReturnsAsync(resultadoEsperado);

            // Act
            var resultado = await _especialidadeServMock.Object.GetAllAsync();

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.NotNull(resultado);
        }

        [Fact(DisplayName = "Consulta Especialidade Por ID Teve Retorna a Especialidade")]
        public async Task GetByIdAsync()
        {
            // Arrange
            var codigoEsperado = 1;
            var resultadoEsperado = new EspecialidadeDTO() { Id = 1, Nome = "Ortopedia" };

            _especialidadeServMock.Setup(setup => setup.GetByIdAsync(codigoEsperado)).ReturnsAsync(resultadoEsperado);

            // Act
            var resultado = await _especialidadeServMock.Object.GetByIdAsync(codigoEsperado);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.NotNull(resultado);
            Assert.Equal(codigoEsperado, resultado.Id);
            Assert.Equal("Ortopedia", resultado.Nome);
        }
    }
}
