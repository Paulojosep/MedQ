using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _service;

        public MedicoController(IMedicoService service)
        {
            _service = service;
        }

        [HttpGet, Route("MedicoByID/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<MedicoDTO>> GetByID(int id)
        {
            var medico = await _service.GetByID(id);
            if(medico == null)
            {
                return NotFound("Medico não econtrado!");
            }
            return Ok(medico);
        }

        [HttpGet, Route("MedicoByEstabelecimento/{estabelecimentoID}")]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> GetByEstabelecimento(int estabelecimentoID)
        {
            var medico = await _service.GetByEstabelecimento(estabelecimentoID);
            if (medico == null)
            {
                return NotFound("Medico não econtrado!");
            }
            return Ok(medico);
        }

        [HttpPost, Route("setMedico")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<MedicoDTO>> CreateMedico([FromBody] MedicoDTO medicoDTO)
        {
            var medico = await _service.Create(medicoDTO);
            if(medico.Equals(null))
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(medico);
        }

        [HttpPut, Route("updateMedico/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<MedicoDTO>> UpdateMedico(int id, [FromBody] MedicoDTO medicoDTO)
        {
            var medicoID = await _service.GetByID(id);
            if (medicoID.Id != id)
            {
                return BadRequest("Medico não econtrado!");
            }
            var medico = await _service.Update(medicoDTO);
            return Ok(medico);
        }

        [HttpDelete, Route("deleteMedico/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<MedicoDTO>> DeletarMedico(int id)
        {
            var medico = await _service.GetByID(id);
            if (medico == null)
            {
                return BadRequest("Medico não econtrado!");
            }
            await _service.Delete(medico);
            return Ok(medico);
        }
    }
}
