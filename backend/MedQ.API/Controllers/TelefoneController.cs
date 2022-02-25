﻿using MedQ.Application.DTOs;
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
        public async Task<ActionResult<TelefoneDTO>> Incluir([FromBody] TelefoneDTO obj)
        {
            var telefone = await _service.CreateAsync(obj);
            if (telefone == null)
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(telefone);
        }

        [HttpPut, Route("Editar/{id}")]
        public async Task<ActionResult<TelefoneDTO>> Editar(int id, [FromBody] TelefoneDTO obj)
        {
            var telefoneID = await _service.GetByIdAsync(id);
            if (telefoneID == null)
            {
                return NotFound("Não foi possivel Econtrar Telefone");
            }
            var telefone = await _service.UpdateAsync(obj);
            return Ok(telefone);
        }
    }
}