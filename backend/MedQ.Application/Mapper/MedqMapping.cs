﻿using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.Mapper
{
    public class MedqMapping : Profile
    {
        public MedqMapping()
        {
            CreateMap<Socio, SocioDTO>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<Consultas, ConsultasDTO>().ReverseMap();
            CreateMap<Fila, FilaDTO>().ReverseMap();
            CreateMap<Mensagens, MensagensDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Estabelecimento, EstabelecimentoDTO>().ReverseMap();
            CreateMap<MinhasConsulta, MinhasConsultaDTO>().ReverseMap();
        }
    }
}