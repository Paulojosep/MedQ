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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _service;

        public EstabelecimentoController(IEstabelecimentoService service)
        {
            _service = service;
        }

        [HttpGet, Route("Listar")]
        public async Task<ActionResult<IEnumerable<EstabelecimentoDTO>>> GetList()
        {
            var estabelecimento = await _service.GetAll();
            return Ok(estabelecimento);
        }

        [HttpGet, Route("ListarPorSocio/{id}")]
        public async Task<ActionResult<IEnumerable<EstabelecimentoDTO>>> GetListBySocio(int id)
        {
            var estabelecimento = await _service.GetBySocio(id);
            return Ok(estabelecimento);
        }

        [HttpGet]
        public async Task<ActionResult<EspecialidadeDTO>> GetEstabelecimento(int id, string nome)
        {
            var estabelecimentoId = await _service.GetEstabelecimento(id, nome);
            if(estabelecimentoId == null)
            {
                return NotFound("Estabelecimento Não Econtrado");
            }
            return Ok(estabelecimentoId);
        }

        [HttpPost, Route("Incluir")]
        public async Task<ActionResult<EstabelecimentoDTO>> Post([FromBody] EstabelecimentoDTO estabelecimentoDTO)
        {
            var estabelecimetno = await _service.Create(estabelecimentoDTO);
            if(estabelecimetno == null)
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(estabelecimetno);
        }

        [HttpPut, Route("Update/{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> Put(int id, [FromBody] EstabelecimentoDTO estabelecimentoDTO)
        {
            var estabelecimentoId = await _service.GetEstabelecimento(id, "");
            if(estabelecimentoId.Id != id)
            {
                return BadRequest("Estabelecimento não econtrado");
            }
            var estabelecimento = await _service.Update(estabelecimentoDTO);
            return Ok();
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> Delete(int id)
        {
            var estabelecimento = await _service.GetEstabelecimento(id, "");
            if (estabelecimento == null)
            {
                return NotFound("Estabelecimento Não Econtrado");
            }
            await _service.Delete(estabelecimento);
            return Ok("Deletado com sucesso");
        }
    }
}
