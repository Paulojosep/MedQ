using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class DesenvolvimentoAuthenticationService : IAuthenticationService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;
        private Usuario _usuario;
        private SocioDTO usuarioLogado;

        public DesenvolvimentoAuthenticationService(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        public void DefinirUsuario(ClaimsPrincipal principal)
        {
            this._usuario = new Usuario()
            {
                Id = 1,
                Nome = "Administrador",
                Email = "admin@gmail.com"
            };
        }

        public async Task<JwtVM> ObterDadosUsuario()
        {
            usuarioLogado = await _usuarioService.Logar("admin@gmail.com", "12345678");
            var jwt = new JwtVM
            {
                Id = 1,
                Nome = usuarioLogado.Nome,
                Email = usuarioLogado.Email,
                Acesso = DateTime.Now,
                Token = _tokenService.Gerar(usuarioLogado),
                EhAdmin = usuarioLogado.EhAdmin,
                Menu = new MenuVM[]
                {
                    new MenuVM { Label = "Consultas", RouterLink = "consultas/lista" }, 
                    new MenuVM { Label = "Telefones", RouterLink = "telefone/listar" },
                    new MenuVM { Label = "Mensagens", RouterLink = "mensagens/lista" }
                }
            };

            return jwt;
        }

        public Usuario RecuperarUsuario()
        {
            return this._usuario;
        }
    }
}
