using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.Services;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedQ.Tests.Services
{
    public class ConsultaServiceTest
    {
        private readonly ConsultaService _consultaService;
        private readonly Mock<IConsultasRepository> _consultaRepoMock = new Mock<IConsultasRepository>();
        private readonly Mock<IMensagensService> _mensageServMock = new Mock<IMensagensService>();
        private readonly Mock<IMinhasConsultaService> _minhaConsultaServMock = new Mock<IMinhasConsultaService>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        public ConsultaServiceTest()
        {
            _consultaService = new ConsultaService(_consultaRepoMock.Object, _mensageServMock.Object, _minhaConsultaServMock.Object, _mapperMock.Object);
        }

        [Fact(DisplayName = "Get By Id Should Retorn Consulta When Consulta Exist")]
        public async Task GetByIdAsync_ShoulRetornConsulta_WhenConsultaExist()
        {
            // Arrange
            var consultaId = 1;
            var consultaStatus = "inativo";
            var consultaEntity = new Consultas{ Id = consultaId, Status = consultaStatus };
            _consultaRepoMock.Setup(repo => repo.GetByIdAsync(consultaId)).ReturnsAsync(consultaEntity);
            var consultaDTO = _mapperMock.Setup(map => map.Map<ConsultasDTO>(consultaEntity));
            // Act
            var consulta = await _consultaService.GetByIdAsync(consultaId);
            // Assert
            Assert.Equal(consultaId, consulta.Id);
            Assert.Equal(consultaStatus, consulta.Status);
        }
    }
}
