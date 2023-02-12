using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Exceptions;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IRepositorioGenerico<Consultas> _repository;
        private readonly IConsultasRepository _consultarRepository;
        private readonly IMensagensService _mensagensService;
        private readonly IMinhasConsultaService _minhasConsultaService;
        private readonly IMapper _mapper;

        public ConsultaService(IRepositorioGenerico<Consultas> repository, IConsultasRepository consultarRepository, IMensagensService mensagensService, IMinhasConsultaService minhasConsultaService, IMapper mapper)
        {
            _repository = repository;
            _consultarRepository = consultarRepository;
            _mapper = mapper;
            _mensagensService = mensagensService;
            _minhasConsultaService = minhasConsultaService;
        }

        public async Task<ConsultasDTO> GetByIdAsync(int id)
        {
            var consultaEntity = await _repository.Obter(x => x.Id == id).FirstOrDefaultAsync();
            var resultado = _mapper.Map<ConsultasDTO>(consultaEntity);
            return resultado;
        }

        public async Task<List<ConsultasPorSocioOutput>> GetBySocioAsync(int socioId)
        {
            var consultaEntity = await _repository.AdicionarInclusoes<Consultas, object>(
                x => x.Agendamento,
                x => x.Socio,
                x => x.Estabelecimento).Where(x => x.SocioId == socioId).ToListAsync();
            var resultado = _mapper.Map<List<ConsultasPorSocioOutput>>(consultaEntity);
            return resultado;
        }

        public async Task<bool> CreateAsync(ConsultasDTO consultas)
        {
            try
            {
                var consultaEntity = _mapper.Map<Consultas>(consultas);
                _repository.Adicionar(consultaEntity);
                return await _repository.SalvarAsync();
            }
            catch(DbUpdateException DbException) {
                throw new MedQException("Erro ao incluir", DbException);
            }
            catch(Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task<bool> UpdateAsync(ConsultasDTO consultas)
        {
            try
            {
                var consultaEntity = _mapper.Map<Consultas>(consultas);
                _repository.Editar(consultaEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException DbException)
            {
                throw new MedQException("Erro ao editar", DbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var consultaEntity = await _repository.Obter(x => x.Id == id).FirstAsync();
                _repository.Deletar(consultaEntity);
                await _repository.SalvarAsync();
            }
            catch (DbUpdateException DbException)
            {
                throw new MedQException("Erro ao editar", DbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task<ConsultasDTO> GetInfosAsync(int id)
        {
            var consultaEntity = await _consultarRepository.GetInfosAsync(id);
            var consultaService = _mapper.Map<ConsultasDTO>(consultaEntity);
            await _mensagensService.CreateConsultationMessage(consultaService);
            return consultaService;
        }

        public async Task<ConsultasDTO> GetInfosForStatusConsultationAsync(int id, string status)
        {
            var consultaEntity = await _consultarRepository.GetInfosAsync(id);
            var consultaService = _mapper.Map<ConsultasDTO>(consultaEntity);
            await _mensagensService.CreateStatusConsultationMessage(consultaService, status);
            return consultaService;
        }

        public async Task<MinhasConsultaInput> GetInfosForConsultation(int id)
        {
            var consultaEntity = await _consultarRepository.GetInfosForConsultationAsync(id);
            var consulta = _mapper.Map<MinhasConsultaInput>(consultaEntity);
            await _minhasConsultaService.CreateMyConsultation(consulta);
            return consulta;
        }
    }
}
