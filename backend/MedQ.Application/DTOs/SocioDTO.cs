﻿using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.DTOs
{
    public class SocioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Image { get; set; }
        public string CodigoVerificacao { get; set; }
        public string IdGoogle { get; set; }
        public string Tipo { get; set; }
        public bool EhAdmin { get; private set; }
    }

    public class UsuarioLogadoDTO
    {
        public UsuarioLogadoDTO(SocioDTO usuario, string token)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Acesso = DateTime.Now;
            Token = token;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Acesso { get; private set; }
        public string Token { get; set; }
    }

    public class UsuarioTrocarSenha
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
    }
}
