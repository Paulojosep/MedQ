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
    public class MinhasConsultaController : ControllerBase
    {
        private readonly IMinhasConsultaService _service;

        public MinhasConsultaController(IMinhasConsultaService service)
        {
            _service = service;
        }

        [HttpGet, Route("Consultas")]
        public async Task<ActionResult<IEnumerable<MinhasConsultaDTO>>> ConsultasGetAll()
        {
            var minhasConsulta = await _service.GetAll();
            if(minhasConsulta == null || minhasConsulta.Count().Equals(0))
            {
                return NotFound("Consultas Não Econtradas!");
            }
            return Ok(minhasConsulta);
        }

        [HttpGet, Route("FinishedMensagens/{socioId}")]
        public async Task<ActionResult<MinhasConsultaDTO>> Mensagens(int socioId)
        {
            var minhasConsulta = await _service.GetFinishedMensagens(socioId);
            if (minhasConsulta == null)
            {
                return NotFound("Mensagen Não Econtradas!");
            }
            return Ok(minhasConsulta);
        }

        [HttpPut, Route("Update")]
        public async Task<ActionResult<MinhasConsultaDTO>> Update([FromBody]MinhasConsultaDTO minhasConsulta)
        {
            var consutas = await _service.UpdateMyConsultation(minhasConsulta);
            return Ok(consutas);
        }
    }
}
