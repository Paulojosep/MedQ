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
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class MensagensService : IMensagensService
    {
        private readonly IRepositorioGenerico<Mensagens> _repository;
        private readonly IMapper _mapper;

        public MensagensService(IRepositorioGenerico<Mensagens> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MensagensDTO> GetViewdMensagens(int socioId)
        {
            return _mapper.Map<MensagensDTO>(await _repository.Obter(x => x.SocioId == socioId).FirstAsync());
        }

        public async Task<MensagensDTO> GetMensagens(int socioId)
        {
            return _mapper.Map<MensagensDTO>(await _repository.Obter(x => x.SocioId == socioId).FirstAsync());
        }

        public async Task<bool> SetViwedTrue(int id)
        {
            try
            {
                var mensagensEntity = await _repository.Obter(x => x.Id == id).FirstAsync();
                _repository.Editar(mensagensEntity);
                return await _repository.SalvarAsync();
            }
            catch(InvalidOperationException ex)
            {
                throw new MedQException("Erro ao localizar entidade", ex);
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

        public async Task<bool> CreateConsultationMessage(ConsultasDTO infoConsultation)
        {
            try
            {
                var estabelecimento_nome = infoConsultation.Estabelecimento.Nome;
                var profissional_nome = infoConsultation.Agendamento.Medico.Nome;
                var consulta_data = infoConsultation.Data.Date;
                var consulta_hora = infoConsultation.Data.Hour;
                var socio_id = infoConsultation.SocioId;
                var consulta_data_formatada = SetDay(consulta_data);
                var mesnsagensEntity = new Mensagens()
                {
                    Titulo = "Consulta Marcada!",
                    Resumo = "Você marcou uma consulta no " + estabelecimento_nome,
                    Texto = $@"Você marcou uma consulta no {estabelecimento_nome} em {consulta_data_formatada} as {consulta_hora}",
                    Data = new DateTime().Date,
                    Hora = new DateTime()
                };
                _repository.Adicionar(mesnsagensEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException DbException)
            {
                throw new MedQException("Erro ao criar mensagens", DbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }

        }

        public async Task<bool> CreateStatusConsultationMessage(ConsultasDTO infoConsultation, string status)
        {
            try
            {
                var estabelecimento_nome = infoConsultation.Estabelecimento.Nome;
                var profissional_nome = infoConsultation.Agendamento.Medico.Nome;
                var consulta_data = infoConsultation.Data.Date;
                var consulta_hora = infoConsultation.Data.Hour;
                var socio_id = infoConsultation.SocioId;
                var consulta_data_formatada = SetDay(consulta_data);
                var mesnsagensEntity = new Mensagens()
                {
                    Titulo = $@"Consulta {status}!",
                    Resumo = $@"Você marcou uma consulta no {estabelecimento_nome}",
                    Texto = $@"Você marcou uma consulta no {estabelecimento_nome} em {consulta_data_formatada} as {consulta_hora}",
                    Data = new DateTime().Date,
                    Hora = new DateTime(),
                };
                _repository.Adicionar(mesnsagensEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException DbException)
            {
                throw new MedQException("Erro ao criar mensagens", DbException);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public string GetDay()
        {
            DateTime date = new DateTime();
            var resultDate = date.Date.ToString();

            return resultDate;
        }

        public string SetDay(DateTime day)
        {
            double days = Convert.ToDouble(day);
            var resultado = days.ToString();
            return resultado;
        }

        public string GetTime()
        {
            DateTime time = new DateTime();
            var resultTime = time.TimeOfDay.ToString();

            return resultTime;
        }
    }
}
