using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class MinhasConsultaService : IMinhasConsultaService
    {
        private IMinhasConsultaRepository _repository;
        private readonly IMapper _mapper;

        public MinhasConsultaService(IMinhasConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MinhasConsultaDTO>> GetAll()
        {
            var minhasConsultaEntity = await _repository.GetAllAsyns();
            var resultado = _mapper.Map<IEnumerable<MinhasConsultaDTO>>(minhasConsultaEntity);
            return resultado;
        }

        public async Task<MinhasConsultaDTO> GetFinishedMensagens(int socioId)
        {
            var minhasConsultaEntity = await _repository.GetFinishedMensagensAsync(socioId);
            var resultado = _mapper.Map<MinhasConsultaDTO>(minhasConsultaEntity);
            return resultado;
        }

        public async Task<bool> CreateMyConsultation(MinhasConsultaInput minhasConsulta)
        {
            try
            {
                var minhasConsultas = _mapper.Map<MinhasConsulta>(minhasConsulta);
                var resultado = await _repository.CreateMyConsultationAsync(minhasConsultas);
                return resultado;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<MinhasConsultaDTO> UpdateMyConsultation(MinhasConsultaDTO minhasConsulta)
        {
            var minhasConsultaEntity = _mapper.Map<MinhasConsulta>(minhasConsulta);
            await _repository.UpdateMyConsultationAsync(minhasConsultaEntity);
            var resultado = _mapper.Map<MinhasConsultaDTO>(minhasConsultaEntity);
            return resultado;
        }

        public async Task DeleteMyConsultation(int id)
        {
            await _repository.DeleteMyConsultationAsync(id);
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
