using AutoMapper;
using Grpc.Net.Client;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class FilaService : IFilaService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioGenerico<Fila> _repository;
        private readonly IMapper _mapper;
        private readonly string url;

        public FilaService(IConfiguration configuration, IRepositorioGenerico<Fila> repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
            this.url = _configuration.GetSection("Api").GetSection("FilaService").Value;
        }

        public async Task<IEnumerable<FilaByEstabelecimentoOutput>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            await Test();
            return _mapper.Map<IEnumerable<FilaByEstabelecimentoOutput>>(await _repository.AdicionarInclusoes<Fila, object>(
                x => x.Especialidade,
                x => x.TipoAtendimento).ToListAsync());
        }

        public async Task<IEnumerable<FilaByTipoAtendimentoOutput>> GetByTipoAtendimentoAsync(int tipoAtendimentoId, int estabelecimentoId)
        {
            var filas = _repository.AdicionarInclusoes<Fila, object>(
                x => x.Especialidade,
                x => x.TipoAtendimento);

            if (tipoAtendimentoId > 0) filas = filas.Where(x => x.TipoAntendimentoId == tipoAtendimentoId);
            if (estabelecimentoId > 0) filas = filas.Where(x => x.EstabelecimentoId == estabelecimentoId);
            return _mapper.Map<IEnumerable<FilaByTipoAtendimentoOutput>>( await filas.ToListAsync());
        }

        public async Task<bool> CreateAsync(FilaDTO fila)
        {
            try
            {
                var filaEntity = _mapper.Map<Fila>(fila);
                _repository.Adicionar(filaEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao incluir", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public async Task Test()
        {
            var canal = GrpcChannel.ForAddress("https://localhost:7053");
            var client = new GrpcService1.Fila.FilaClient(canal);
            var reply = await client.GetFilaAsync(new GrpcService1.FilaRequest { FilaName = "Paulo"});
            Console.WriteLine("Greeting: " + reply.Message);
        }
    }
}
