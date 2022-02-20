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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _service;

        public EspecialidadeController(IEspecialidadeService service)
        {
            _service = service;
        }

        [HttpGet, Route("Listar")]
        public async Task<ActionResult<IEnumerable<EspecialidadeDTO>>> GetList()
        {
            var especialidade = await _service.GetAllAsync();
            return Ok(especialidade);
        }

        [HttpGet, Route("EspecialidadePorId/{id}")]
        public async Task<ActionResult<IEnumerable<EspecialidadeDTO>>> GetById(int id)
        {
            var especialidade = await _service.GetByIdAsync(id);
            if (especialidade == null)
            {
                return NotFound("Especialidade Não Econtrado");
            }
            return Ok(especialidade);
        }

        [HttpGet, Route("EspecialidadePorEstabelecimento/{estabelecimentoId}")]
        public async Task<ActionResult<IEnumerable<EspecialidadeDTO>>> GetByEstabelecimento(int estabelecimentoId)
        {
            var especialidade = await _service.GetByEstabelecimentoAsync(estabelecimentoId);
            if (especialidade == null)
            {
                return NotFound("Especialidade por Estabelecimento Não Econtrado");
            }
            return Ok(especialidade);
        }
    }
}
