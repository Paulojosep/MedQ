using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class MensagensRepository : IMensagensRepository
    {
        private readonly IRepositorioGenerico<Mensagens> _repository;

        public MensagensRepository(IRepositorioGenerico<Mensagens> repository)
        {
            _repository = repository;
        }

        public async Task<Mensagens> GetByIdAsync(int id)
        {
            return await _repository.Obter(x => x.Id == id).FirstAsync();
        }

        public async Task<Mensagens> GetMensagensAsync(int socioId)
        {
            return await _repository.Obter(x => x.SocioId == socioId).FirstAsync();
        }

        public async Task<Mensagens> GetViewdMensagensAsync(int socioId)
        {
            return await _repository.Obter(x => x.SocioId == socioId).FirstAsync();
        }

        public async Task<Mensagens> CreateAsync(Mensagens mensagens)
        {
            _repository.Adicionar(mensagens);
            await _repository.SalvarAsync();
            return mensagens;
        }

        public async Task<Mensagens> SetViwedTrueAsync(Mensagens mensagens)
        {
            _repository.Editar(mensagens);
            await _repository.SalvarAsync();
            return mensagens;
        }

        public async Task CreateConsultationMessage(string titulo, string resumo, string texto, string data, string hora, int socio_id)
        {
            using(var ctx = new MedQContext())
            {
                var resultado = await ctx.Database.ExecuteSqlRawAsync($@"INSERT INTO tb_mensagens (titulo, resumo, texto, data, hora, fk_socio_id) VALUES ({titulo},{resumo},{texto},{data},{hora},{socio_id})");
                if (resultado == 1)
                {
                    Console.WriteLine("Erro");
                }
                else
                {
                    Console.WriteLine("Mensagem da consulta criada com sucesso!");
                }
            }
        }
    }
}
