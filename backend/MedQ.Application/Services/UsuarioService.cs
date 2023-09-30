﻿using AutoMapper;
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
        private readonly ISocioService _socioService;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, ISocioService socioService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _socioService = socioService;
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

        public async Task<bool> SiginUp(SocioDTO socio)
        {
            try
            {
                var usuario = await _socioService.GetBySocioAsync(0, socio.CPF);
                if (usuario != null) throw new MedQException("Usuario já existe");
                if (!Validacoes.Senha(socio.Senha)) throw new MedQException("Senha Invalida");
                socio.Senha = Seguranca.HashMd5(socio.Senha);
                return await _socioService.CreateAsync(socio);
            }
            catch(Exception ex)
            {
                throw new MedQException(ex.Message);
            }
        }
    }
}
