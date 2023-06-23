using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Exceptions;
using MedQ.Application.Interfaces;
using MedQ.Application.Utils;
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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<SocioDTO> Logar(string login, string senha)
        {
            try
            {
                if(string.IsNullOrEmpty(login) && string.IsNullOrEmpty(senha))
                {
                    throw new MedQException("Informe os dados para login");
                }

                var usuario = await _usuarioRepository.Logar(login, Seguranca.HashMd5(senha));

                if(usuario != null)
                {
                    return _mapper.Map<SocioDTO>(usuario);
                }
                else
                {
                    throw new MedQException("Usuário ou senha inválido");
                }
            }
            catch(Exception ex)
            {
                throw new MedQException(ex.Message);
            }
        }
    }
}
