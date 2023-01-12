using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Application.IO;
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
        public async Task<IActionResult> GetBySocio(int socioId)
        {
            var consulta = await _service.GetBySocioAsync(socioId);
            if (consulta == null)
            {
                return NotFound("Consulta por Socio não econtrado!");
            }
            return Ok(consulta);
        }

        [HttpPost, Route("Incluir")]
        public async Task<IActionResult> Incluir([FromBody] ConsultasDTO consultas)
        {
            return Ok(await _service.CreateAsync(consultas));
        }

        [HttpPut, Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ConsultasDTO consultas)
        {
            return Ok(await _service.UpdateAsync(consultas));
        }

        [HttpDelete, Route("Deletar/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
