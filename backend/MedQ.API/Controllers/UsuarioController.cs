using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
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
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioLogadoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpGet("VersionMedq")]
        public IActionResult VersionMedq()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo file_info = new FileInfo(strExeFilePath);
            string modificado = file_info.LastWriteTime.ToString("dd/MM/yyyy - HH:mm");
            return new JsonResult(modificado);
        }
    }
}
