using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<SocioDTO>>> GetList()
        {
            var socios = await _service.GetSocioAsync();
            if(socios == null)
            {
                return NotFound("Socio Não Econtrado");
            }
            return Ok(socios);
        }

        [HttpGet, Route("UsuarioPorId/{id}")]
        public async Task<ActionResult<SocioDTO>> GetById(int id)
        {
            var socios = await _service.GetByIdAsync(id);
            if (socios == null)
            {
                return NotFound("Socio Não Econtrado");
            }
            return Ok(socios);
        }

        [HttpGet, Route("UsuarioPorCPF/{cpf}")]
        public async Task<ActionResult<SocioDTO>> GetByCPF(string cpf)
        {
            var socios = await _service.GetByCPFAsync(cpf);
            if (socios == null)
            {
                return NotFound("Socio Não Econtrado");
            }
            return Ok(socios);
        }
    }
}
