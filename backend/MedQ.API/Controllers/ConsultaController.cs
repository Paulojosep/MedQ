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
        public async Task<ActionResult<List<ConsultasPorSocioOutput>>> GetBySocio(int socioId)
        {
            var consulta = await _service.GetBySocioAsync(socioId);
            if (consulta == null)
            {
                return NotFound("Consulta por Socio não econtrado!");
            }
            return Ok(consulta);
        }

        [HttpPost, Route("Incluir")]
        public async Task<ActionResult<ConsultasDTO>> Incluir([FromBody] ConsultasDTO consultas)
        {
            var consulta = await _service.CreateAsync(consultas);
            if (consulta == null)
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(consulta);
        }

        [HttpPut, Route("Editar/{id}")]
        public async Task<ActionResult<ConsultasDTO>> Editar(int id, [FromBody] ConsultasDTO consultas)
        {
            var consultaID = await _service.GetByIdAsync(id);
            if (consultaID.Id != id)
            {
                return BadRequest("Não foi possivel Econtrar a Consulta");
            }
            var consulta = await _service.UpdateAsync(consultas);
            return Ok(consulta);
        }

        [HttpDelete, Route("Deletar/{id}")]
        public async Task<ActionResult<ConsultasDTO>> Deletar(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
