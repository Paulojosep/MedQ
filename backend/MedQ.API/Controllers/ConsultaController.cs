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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;

        public ConsultaController(IConsultaService service)
        {
            _service = service;
        }

        [HttpGet, Route("ConsultarPorSocio/{socioId}")]
        public async Task<ActionResult<ConsultasDTO>> GetBySocio(int socioId)
        {
            var consulta = await _service.GetBySocioAsync(socioId);
            if (consulta == null)
            {
                return NotFound("Consulta por Socio não econtrado!");
            }
            return Ok(consulta);
        }
    }
}
