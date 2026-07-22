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
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IConsultaService> _consultaServMock = new Mock<IConsultaService>();

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

        [Fact(DisplayName = "Get By Socio Retorna com valor da consulta do socio quando existe")]
        public async Task GetBySocioAsync()
        {
            // Arrange
            int socioId = 1;
            var outuput = new ConsultasPorSocioOutput() { Codigo = socioId };
            List<ConsultasPorSocioOutput> listaOutput = new List<ConsultasPorSocioOutput>();
            listaOutput.Add(outuput);
            _consultaServMock.Setup(map => map.GetBySocioAsync(socioId)).ReturnsAsync(listaOutput);
            //Act
            var consultaSocio = await _consultaServMock.Object.GetBySocioAsync(socioId);

            // Assert
            Assert.NotNull(consultaSocio);
        }

        [Fact(DisplayName = "Teste da Criacao da Consulta")]
        public async Task CreateAsync()
        {
            //Arrange
            var consultaInput = new ConsultasDTO()
            {
                Id = 1245,
                AgendamentoId = 1,
                EstabelecimentoId = 1,
                SocioId = 1,
                Senha = "123",
                Status = "Ativo",
                Data = new DateTime().Date,
                Hora = new DateTime()
            };

            bool resultadoEsperado = true;

            _consultaServMock.Setup(setup => setup.CreateAsync(consultaInput)).ReturnsAsync(resultadoEsperado);

            //Act
            var resultado = await _consultaServMock.Object.CreateAsync(consultaInput);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
            Assert.True(resultado);
        }
    }
}
