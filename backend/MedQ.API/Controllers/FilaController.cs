﻿using MedQ.Application.DTOs;
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
    public class FilaController : ControllerBase
    {
        private readonly IFilaService _service;

        public FilaController(IFilaService service)
        {
            _service = service;
        }

        [HttpGet, Route("PegarPorEstabelecimento/{estabelecimentoId}")]
        public async Task<ActionResult> GetByEstabelecimento(int estabelecimentoId)
        {
            var fila = await _service.GetByEstabelecimentoAsync(estabelecimentoId);
            if(fila == null)
            {
                return NotFound("Fila Não Econtrado");
            }
            return Ok(fila);
        }

        [HttpGet, Route("PegarPorTipoAtendimento/{tipoAtendimentiId}/{estabelecimentoId}")]
        public async Task<ActionResult> GetByTipoAtendimento(int tipoAtendimentiId, int estabelecimentoId)
        {
            var fila = await _service.GetByTipoAtendimentoAsync(tipoAtendimentiId, estabelecimentoId);
            if (fila == null)
            {
                return NotFound("Fila Não Econtrado");
            }
            return Ok(fila);
        }

        [HttpPost, Route("SetFila")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<FilaDTO>> CreateFila([FromBody] FilaDTO filaDTO)
        {
            var fila = await _service.CreateAsync(filaDTO);
            if (fila.Equals(null))
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(fila);
        }
    }
}
