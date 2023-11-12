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
    public class AgendamentoDisponivelService : IAgendamentoDisponivelService
    {
        private readonly IRepositorioGenerico<AgendamentoDisponiveis> _repositorio;
        private readonly IMapper _mapper;

        public AgendamentoDisponivelService(IRepositorioGenerico<AgendamentoDisponiveis> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<AgendamentoDisponiveisDTO>> GetAll()
        {
            return _mapper.Map<List<AgendamentoDisponiveisDTO>>(await _repositorio.SelecionarTodos());
        }

        public async Task<AgendamentoDisponiveisDTO> GetById(int id)
        {
            return _mapper.Map<AgendamentoDisponiveisDTO>(await _repositorio.Obter(x => x.Id.Equals(id)).FirstOrDefaultAsync());
        }

        public async Task<List<AgendamentoDisponiveisDTO>> GetByEstabelecimento(int establelcimentoId)
        {
            return _mapper.Map<List<AgendamentoDisponiveisDTO>>(await _repositorio.AdicionarInclusoes<AgendamentoDisponiveis, object>(x => x.Medico, x => x.Estabelecmento)
                .Where(x => x.EstabelecimentoId.Equals(establelcimentoId))
                .ToListAsync());
        }

        public async Task<List<AgendamentoDisponiveisDTO>> GetByStatus(int establelcimentoId)
        {
            return _mapper.Map<List<AgendamentoDisponiveisDTO>>(await _repositorio.AdicionarInclusoes<AgendamentoDisponiveis, object>(x => x.Medico, x => x.Estabelecmento)
                .Where(x => x.EstabelecimentoId.Equals(establelcimentoId) && x.Disponibilidade.Equals(0))
                .ToListAsync());
        }

        public async Task<List<AgendamentoDisponiveisDTO>> GetAgendamentoDisponivel(AgendamentoDisponivelInput input)
        {
            var query = _repositorio.AdicionarInclusoes<AgendamentoDisponiveis, object>(x => x.Medico)
                .Where(x => x.Medico.EstabelecimentoId.Equals(input.EstabelecimentoId) && x.Medico.EspecialidadeId.Equals(input.EspecialidadeId) && x.Disponibilidade.Equals(1));

            if(input.Data.HasValue)
            {
                query = query.Where(x => x.Data >= input.Data);
            }
            if(input.HoraInicio.HasValue && input.HoraFim.HasValue)
            {
                query = query.Where(x => x.Hora >= input.HoraInicio && x.Hora <= input.HoraFim);
            }

            return _mapper.Map<List<AgendamentoDisponiveisDTO>>(await query.ToListAsync());
        }

        public async Task<bool> updateDisponibilidade(AgendamentoDisponivelAtualizacaoDisponibilidadeInput input)
        {
            try
            {
                var agendamento = await _repositorio.Obter(x => x.Id.Equals(input.Id)).FirstOrDefaultAsync();
                if (agendamento.Equals(null)) throw new MedQException("Agendamento não econtrado");
                agendamento.Disponibilidade = input.Disponibilidade;
                _repositorio.Editar(agendamento);
                return await _repositorio.SalvarAsync();
            }
            catch(Exception ex)
            {
                throw new MedQException(ex.Message, ex.InnerException);
            }
        }
    }
}
