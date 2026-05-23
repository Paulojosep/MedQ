using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Application.Services;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedQ.Tests.Services
{
    public class ConsultaServiceTest
    {
        private readonly Mock<IConsultaService> _consultaServiceMock;
        private readonly Mock<IRepositorioGenerico<Consultas>> _consultaRepoGenMock = new Mock<IRepositorioGenerico<Consultas>>();
        private readonly Mock<IConsultasRepository> _consultaRepoMock = new Mock<IConsultasRepository>();
        private readonly Mock<IMensagensService> _mensageServMock = new Mock<IMensagensService>();
        private readonly Mock<IMinhasConsultaService> _minhaConsultaServMock = new Mock<IMinhasConsultaService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly Mock<IConsultaService> _consultaServMock = new Mock<IConsultaService>();

        public ConsultaServiceTest(Mock<IConsultaService> consultaServiceMock)
        {
            //_consultaService = new ConsultaService(_consultaRepoGenMock.Object, _consultaRepoMock.Object, _mensageServMock.Object, _minhaConsultaServMock.Object, _mapperMock.Object);
            _consultaServMock = consultaServiceMock;
        }

        [Fact(DisplayName = "Get By Id Should Retorn Consulta When Consulta Exist")]
        public async Task GetByIdAsync_ShoulRetornConsulta_WhenConsultaExist()
        {
            // Arrange
            var consultaId = 1;
            var consultaStatus = "inativo";
            var consultaEntity = new Consultas{ Id = consultaId, Status = consultaStatus };
            //_consultaRepoGenMock.Setup(repo => repo.ObterPorCodigoAsync(consultaId)).ReturnsAsync(consultaEntity);
            var consultaDTO = _mapperMock.Setup(map => map.Map<ConsultasDTO>(consultaEntity));
            
            var mockService = new Mock<IConsultaService>();
            mockService.Setup(s => s.GetByIdAsync(consultaId)).ReturnsAsync(new ConsultasDTO() { Id = consultaId, Status = consultaStatus });
            // Act
            var consulta = await mockService.Object.GetByIdAsync(consultaId);
            // Assert
            Assert.Equal(consultaId, consulta.Id);
            Assert.Equal(consultaStatus, consulta.Status);
        }

        [Fact]
        public async Task GetBySocioAsync()
        {
            // Arrange
            int socioId = 1;
            var outuput = new ConsultasPorSocioOutput() { Codigo = socioId };
            var lista = new List<ConsultasPorSocioOutput>();
            lista.Add(outuput);
            //mockService.Setup(map => map.GetBySocioAsync(socioId)).ReturnsAsync(lista);
            //Act
            var consultaSocio = await _consultaServMock.Object.GetByIdAsync(socioId);

            // Assert
            Assert.Equal(socioId, consultaSocio.SocioId);
        }
    }
}
