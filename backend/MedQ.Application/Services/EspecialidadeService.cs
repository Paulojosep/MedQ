using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
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
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IRepositorioGenerico<Especialidade> _repository;
        private readonly IRepositorioGenerico<Fila> _filaRepsitorio;
        private readonly IMapper _mapper;

        public EspecialidadeService(IRepositorioGenerico<Especialidade> repository, IRepositorioGenerico<Fila> filaRepsitorio, IMapper mapper)
        {
            _repository = repository;
            _filaRepsitorio = filaRepsitorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EspecialidadeDTO>>(await _repository.SelecionarTodos());
        }

        public async Task<EspecialidadeDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<EspecialidadeDTO>(await _repository.Obter(x => x.Id ==id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetByEstabelecimentoAsync(int idEstabelecimento)
        {
            var filaEntity = await _filaRepsitorio.AdicionarInclusoes<Fila, object>(x => x.Especialidade).Where(x => x.EspecialidadeId == idEstabelecimento).Select(x => x.Id).ToListAsync();
            return _mapper.Map<IEnumerable<EspecialidadeDTO>>(await _repository.AdicionarInclusoes<Especialidade, object>(x => x.Filas,
                x => x.Medicos).Where(x => filaEntity.Contains(x.Id)).ToListAsync());
        }
    }
}
