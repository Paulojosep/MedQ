using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MedQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly ISocioService _service;

        public SocioController(ISocioService service)
        {
            _service = service;
        }

        [HttpGet, Route("Listar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<SocioDTO>>> GetList()
        {
            var socios = await _service.GetSocioAsync();
            if(socios == null)
            {
                return NotFound("Socio Não Econtrado");
            }
            return Ok(socios);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<SocioDTO>> GetBySocio(int id, string cpf)
        {
            var socios = await _service.GetBySocioAsync(id, cpf);
            if (socios == null)
            {
                return NotFound("Socio Não Econtrado");
            }
            return Ok(socios);
        }
    }
}
