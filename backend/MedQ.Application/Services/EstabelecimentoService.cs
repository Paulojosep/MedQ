using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private IEstabelecimentoRepository _repository;
        private readonly IMapper _mapper;

        public EstabelecimentoService(IEstabelecimentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EstabelecimentoDTO>> GetAll()
        {
            var estabelecimentoEntity = await _repository.GetAllAsync();
            var resultado = _mapper.Map<IEnumerable<EstabelecimentoDTO>>(estabelecimentoEntity);
            return resultado;
        }

        public async Task<EstabelecimentoDTO> GetEstabelecimento(int id, string nome)
        {
            var estabelecimentoEntity = await _repository.GetEstabelecimentoAsync(id, nome);
            var resultado = _mapper.Map<EstabelecimentoDTO>(estabelecimentoEntity);
            return resultado;
        }

        public async Task<IEnumerable<EstabelecimentoDTO>> GetBySocio(int socioId)
        {
            var estabelecimentoEntity = await _repository.GetBySocioAsync(socioId);
            var resultado = _mapper.Map<IEnumerable<EstabelecimentoDTO>>(estabelecimentoEntity);
            return resultado;
        }

        public async Task<EstabelecimentoDTO> Create(EstabelecimentoDTO estabelecimento)
        {
            var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
            await _repository.CreateAsync(estabelecimentoEntity);
            var resultado = _mapper.Map<EstabelecimentoDTO>(estabelecimentoEntity);
            return resultado;
        }

        public async Task<EstabelecimentoDTO> Update(EstabelecimentoDTO estabelecimento)
        {
            var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
            await _repository.UpdateAsync(estabelecimentoEntity);
            var resultado = _mapper.Map<EstabelecimentoDTO>(estabelecimentoEntity);
            return resultado;
        }

        public async Task Delete(EstabelecimentoDTO estabelecimento)
        {
            var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
            await _repository.DeleteAsync(estabelecimentoEntity);
        }
    }
}
