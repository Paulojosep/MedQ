using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEmailService _emailService;

        public UsuarioController(IUsuarioService usuarioService, IEmailService emailService)
        {
            _usuarioService = usuarioService;
            _emailService = emailService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Logon login)
        {
            try
            {
                var usuario = await _usuarioService.Logar(login.Login, login.Senha);
                return Ok(new UsuarioLogadoDTO(usuario, TokenService.Gerar(usuario)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SingUp([FromBody] SocioDTO usuario)
        {
            try
            {
                string resultado = string.Empty;
                var ehVerdadeiro = await _usuarioService.SiginUp(usuario);
                if (ehVerdadeiro.Equals(true))
                {
                    resultado = "Usario cadastrado com sucesso, você recebera um email para validar o acesso";
                    var emailText = new EmailDTO("paulo", "paulo.jmodesto75@gmail.com", usuario.Email, "Cadastro do MedQ", "Seu cadastro foi realizado com sucesso");
                    var email = await _emailService.SendEmail(emailText);
                }
                else
                {
                    return BadRequest($"Usuario com {usuario.CPF} Já cadastrado");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
