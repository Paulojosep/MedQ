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
    public class MensagensController : ControllerBase
    {
        private readonly IMensagensService _service;

        public MensagensController(IMensagensService service)
        {
            _service = service;
        }

        [HttpGet, Route("Mensagens/{socioId}")]
        public async Task<ActionResult<MensagensDTO>> GetMensagens(int socioId)
        {
            var mensagens = await _service.GetMensagens(socioId);
            if(mensagens == null)
            {
                return NotFound("Mensagens não econtrada!");
            }
            return Ok(mensagens);
        }

        [HttpGet, Route("ViewdMensagens/{socioId}")]
        public async Task<ActionResult<MensagensDTO>> GetViewdMensagens(int socioId)
        {
            var mensagens = await _service.GetViewdMensagens(socioId);
            if (mensagens == null)
            {
                return NotFound("Mensagens não econtrada!");
            }
            return Ok(mensagens);
        }

        [HttpPut, Route("ViewedTrue/{id}")]
        public async Task<ActionResult<MensagensDTO>> SetViewedTrue(int id)
        {
            var mensageID = await _service.SetViwedTrue(id);
            if(mensageID.Equals(null))
            {
                return NotFound("Não foi possivel Encontrar Viewd");
            }
            return Ok(mensageID);
        }
    }
}
