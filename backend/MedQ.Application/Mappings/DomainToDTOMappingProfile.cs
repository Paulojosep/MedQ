using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Socio, SocioDTO>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<Consultas, ConsultasDTO>().ReverseMap();
            CreateMap<Fila, FilaDTO>().ReverseMap();
            CreateMap<Mensagens, MensagensDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<MinhasConsulta, MinhasConsultaDTO>().ReverseMap();
        }
    }
}
