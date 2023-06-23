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

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Logon login)
        {
            try
            {
                var usuario = await _usuarioService.Logar(login.Login, login.Senha);
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
