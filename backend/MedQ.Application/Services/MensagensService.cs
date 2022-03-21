using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class MensagensService : IMensagensService
    {
        private IMensagensRepository _repository;
        private readonly IMapper _mapper;

        public MensagensService(IMensagensRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MensagensDTO> GetViewdMensagens(int socioId)
        {
            var mensagensEntity = await _repository.GetViewdMensagensAsync(socioId);
            return _mapper.Map<MensagensDTO>(mensagensEntity);
        }

        public async Task<MensagensDTO> GetMensagens(int socioId)
        {
            var mensagensEntity = await _repository.GetMensagensAsync(socioId);
            return _mapper.Map<MensagensDTO>(mensagensEntity);
        }

        public async Task<MensagensDTO> SetViwedTrue(int id)
        {
            var mensagensEntity = await _repository.GetByIdAsync(id);
            await _repository.SetViwedTrueAsync(mensagensEntity);
            var resultado = _mapper.Map<MensagensDTO>(mensagensEntity);
            return resultado;
        }

        public async Task CreateConsultationMessage(ConsultasDTO infoConsultation)
        {
            var estabelecimento_nome = infoConsultation.Estabelecimento.Nome;
            var profissional_nome = infoConsultation.Agendamento.Medico.Nome;
            var consulta_data = infoConsultation.Data.Date;
            var consulta_hora = infoConsultation.Data.Hour;
            var socio_id = infoConsultation.SocioId;

            var consulta_data_formatada = SetDay(consulta_data);
            var titulo = "Consulta Marcada!";
            var resumo = "Você marcou uma consulta no " + estabelecimento_nome;
            var texto = $@"Você marcou uma consulta no {estabelecimento_nome} em {consulta_data_formatada} as {consulta_hora}";

            var data = GetDay();
            var hora = GetTime();

            await _repository.CreateConsultationMessage(titulo, resumo, texto, data, hora, socio_id);

        }

        public async Task CreateStatusConsultationMessage(ConsultasDTO infoConsultation, string status)
        {
            var estabelecimento_nome = infoConsultation.Estabelecimento.Nome;
            var profissional_nome = infoConsultation.Agendamento.Medico.Nome;
            var consulta_data = infoConsultation.Data.Date;
            var consulta_hora = infoConsultation.Data.Hour;
            var socio_id = infoConsultation.SocioId;

            var consulta_data_formatada = SetDay(consulta_data);
            var titulo = $@"Consulta {status}!";
            var resumo = "Você marcou uma consulta no " + estabelecimento_nome;
            var texto = $@"Você marcou uma consulta no {estabelecimento_nome} em {consulta_data_formatada} as {consulta_hora}";

            var data = GetDay();
            var hora = GetTime();

            await _repository.CreateConsultationMessage(titulo, resumo, texto, data, hora, socio_id);
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
