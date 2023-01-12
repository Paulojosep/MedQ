using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Exceptions;
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
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IRepositorioGenerico<Estabelecimento> _repository;
        private readonly IMapper _mapper;

        public EstabelecimentoService(IRepositorioGenerico<Estabelecimento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EstabelecimentoDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<EstabelecimentoDTO>>(await _repository.SelecionarTodos());
        }

        public async Task<EstabelecimentoDTO> GetEstabelecimento(int id, string nome)
        {
            if (String.IsNullOrEmpty(nome) && id.Equals(null)) throw new MedQException("Parametros deve ser informados");
            var estabelecimentoEntity = _repository.AdicionarInclusoes<Estabelecimento, object>(
                x => x.Socio,
                x => x.TipoEstbelecimento);

            if (!String.IsNullOrEmpty(nome)) estabelecimentoEntity = estabelecimentoEntity.Where(x => x.Nome == nome);
            if (id > 0) estabelecimentoEntity = estabelecimentoEntity.Where(x => x.Id == id);
            return _mapper.Map<EstabelecimentoDTO>(await estabelecimentoEntity.FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<EstabelecimentoDTO>> GetBySocio(int socioId)
        {
            return _mapper.Map<IEnumerable<EstabelecimentoDTO>>(await _repository.AdicionarInclusoes<Estabelecimento, object>(
                x => x.Socio).Where(x => x.SocioId == socioId).ToListAsync());
        }

        public async Task<bool> Create(EstabelecimentoDTO estabelecimento)
        {
            try
            {
                var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
                _repository.Adicionar(estabelecimentoEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw new MedQException("Erro ao fazer inclusao", dbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task<bool> Update(EstabelecimentoDTO estabelecimento)
        {
            try
            {
                var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
                _repository.Editar(estabelecimentoEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw new MedQException("Erro ao fazer editar", dbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task Delete(EstabelecimentoDTO estabelecimento)
        {
            try
            {
                var estabelecimentoEntity = _mapper.Map<Estabelecimento>(estabelecimento);
                _repository.Deletar(estabelecimentoEntity);
                await _repository.SalvarAsync();
            }
            catch (DbUpdateException dbException)
            {
                throw new MedQException("Erro ao excluir", dbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }
    }
}
