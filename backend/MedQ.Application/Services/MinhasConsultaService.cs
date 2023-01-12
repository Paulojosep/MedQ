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
    public class MinhasConsultaService : IMinhasConsultaService
    {
        private readonly IRepositorioGenerico<MinhasConsulta> _repository;
        private readonly IMapper _mapper;

        public MinhasConsultaService(IRepositorioGenerico<MinhasConsulta> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MinhasConsultaDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<MinhasConsultaDTO>>(await _repository.SelecionarTodos());
        }

        public async Task<string> GetFinishedMensagens(int socioId)
        {
            return _mapper.Map<string>(await _repository.Obter(x => x.SocioId == socioId).Select(s => s.Finished).FirstOrDefaultAsync());
        }

        public async Task<bool> CreateMyConsultation(MinhasConsultaInput minhasConsulta)
        {
            try
            {
                var minhasConsultas = _mapper.Map<MinhasConsulta>(minhasConsulta);
                _repository.Adicionar(minhasConsultas);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao incluir", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task<bool> UpdateMyConsultation(MinhasConsultaDTO minhasConsulta)
        {
            try
            {
                var minhasConsultas = _mapper.Map<MinhasConsulta>(minhasConsulta);
                _repository.Editar(minhasConsultas);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao editar", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task DeleteMyConsultation(int id)
        {
            try
            {
                var minhasConsultas = await _repository.Obter(x => x.Id == id).FirstOrDefaultAsync();
                if (minhasConsultas == null) throw new MedQException($@"Não foi possivel deletar ID: {id}, ela já foideletada");
                _repository.Deletar(minhasConsultas);
                await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao deletar", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        private string MakeId()
        {
            Random random = new Random();
            var pedido = "";
            var possibilidade = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for(int i = 0; i < 16; i++)
            {
                possibilidade = Convert.ToString(Math.Floor(random.NextDouble() * possibilidade.Length));
                pedido += possibilidade;
            }
            return pedido;
        }
    }
}
