using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.IO;
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
            CreateMap<Consultas, ConsultasPorSocioOutput>()
                .ForMember(x => x.Medico, y => y.MapFrom(z => z.Agendamento.Medico.Nome))
                .ForMember(x => x.Especialidade, y => y.MapFrom(z => z.Agendamento.Medico.Especialidade.Nome))
                .ReverseMap();
            CreateMap<Fila, FilaDTO>().ReverseMap();
            CreateMap<Fila, FilaByEstabelecimentoOutput>()
                .ForMember(d => d.QtdPessoas, o => o.MapFrom(opt => opt.QtdPessoas))
                .ForMember(d => d.Tipo, o => o.MapFrom(opt => opt.TipoAtendimento.Tipo))
                .ForMember(d => d.NomeEspecialidade, o => o.MapFrom(opt => opt.Especialidade.Nome))
                .ReverseMap();
            CreateMap<Fila, FilaByTipoAtendimentoOutput>()
                .ForMember(d => d.ID, o => o.MapFrom(opt => opt.Id))
                .ForMember(d => d.QtdPessoas, o => o.MapFrom(opt => opt.QtdPessoas))
                .ForMember(d => d.DataCadastro, o => o.MapFrom(opt => opt.DataCadastro))
                .ForMember(d => d.TipoAntendimentoId, o => o.MapFrom(opt => opt.TipoAntendimentoId))
                .ForMember(d => d.EstabelecimentoId, o => o.MapFrom(opt => opt.EstabelecimentoId))
                .ForMember(d => d.EspecialidadeId, o => o.MapFrom(opt => opt.EspecialidadeId))
                .ForMember(d => d.EspecialidadeNome, o => o.MapFrom(opt => opt.Especialidade.Nome))
                .ForMember(d => d.EspecialidadeDescricao, o => o.MapFrom(opt => opt.Especialidade.Descricao))
                .ReverseMap();
            CreateMap<Mensagens, MensagensDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Estabelecimento, EstabelecimentoDTO>().ReverseMap();
            CreateMap<MinhasConsulta, MinhasConsultaDTO>().ReverseMap();
            CreateMap<TipoAtendimento, TipoAtendimentoDTO>().ReverseMap();
        }
    }
}
