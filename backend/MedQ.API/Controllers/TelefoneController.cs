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
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _service;

        public TelefoneController(ITelefoneService service)
        {
            _service = service;
        }

        [HttpGet, Route("Listar")]
        public async Task<ActionResult<IEnumerable<TelefoneDTO>>> GetList()
        {
            var telefones = await _service.GetAllAsync();
            if (telefones == null)
            {
                return NotFound("Telefone Não Econtrado");
            }
            return Ok(telefones);
        }

        [HttpPost, Route("Incluir")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TelefoneDTO>> Incluir([FromBody] TelefoneDTO obj)
        {
            var telefone = await _service.CreateAsync(obj);
            if (telefone.Equals(null))
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(telefone);
        }

        [HttpPut, Route("Editar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TelefoneDTO>> Editar([FromBody] TelefoneDTO obj)
        {
            var telefoneID = await _service.GetByIdAsync(obj.Id);
            if (telefoneID == null)
            {
                return NotFound("Não foi possivel Econtrar Telefone");
            }
            var telefone = await _service.UpdateAsync(obj);
            return Ok(telefone);
        }
    }
}
