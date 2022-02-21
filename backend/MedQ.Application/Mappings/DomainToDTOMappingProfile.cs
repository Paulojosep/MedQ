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
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
        }
    }
}
