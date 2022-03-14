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

        public string GetDay()
        {
            DateTime date = new DateTime();
            var resultDate = date.Date.ToString();

            return resultDate;
        }

        public string SetDay(string day)
        {
            DateTime date = new DateTime();
            double days = Convert.ToDouble(day);
            var resultado = date.AddDays(days).ToString();
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
