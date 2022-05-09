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

        [HttpGet, Route("EstabelecimentoPorId/{id}")]
        public async Task<ActionResult<EspecialidadeDTO>> GetById(int id)
        {
            var estabelecimentoId = await _service.GetById(id);
            if(estabelecimentoId == null)
            {
                return NotFound("Estabelecimento Não Econtrado");
            }
            return Ok(estabelecimentoId);
        }

        [HttpGet, Route("EstabelecimentoPorNome/{nome}")]
        public async Task<ActionResult<EspecialidadeDTO>> GetByNome(string nome)
        {
            var estabelecimento = await _service.GetByNome(nome);
            if (estabelecimento == null)
            {
                return NotFound("Estabelecimento Não Econtrado");
            }
            return Ok(estabelecimento);
        }

        [HttpPost, Route("SetEstabelecimento")]
        public async Task<ActionResult<EstabelecimentoDTO>> CreateEstabelecimento([FromBody] EstabelecimentoDTO estabelecimentoDTO)
        {
            var estabelecimetno = await _service.Create(estabelecimentoDTO);
            if(estabelecimetno == null)
            {
                return BadRequest("Não foi possivel Cadastrar");
            }
            return Ok(estabelecimetno);
        }

        [HttpPut, Route("UpdateEstabelecimento/{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> UpdateEstabelecimento(int id, [FromBody] EstabelecimentoDTO estabelecimentoDTO)
        {
            var estabelecimentoId = await _service.GetById(id);
            if(estabelecimentoId.Id != id)
            {
                return BadRequest("Estabelecimento não econtrado");
            }
            var estabelecimento = await _service.Update(estabelecimentoDTO);
            return Ok(estabelecimento);
        }

        [HttpDelete, Route("DeleteEstabelecimento/{id}")]
        public async Task<ActionResult<EstabelecimentoDTO>> DeletarEstabelecimento(int id)
        {
            var estabelecimento = await _service.GetById(id);
            if (estabelecimento == null)
            {
                return NotFound("Estabelecimento Não Econtrado");
            }
            await _service.Delete(estabelecimento);
            return Ok(estabelecimento);
        }
    }
}
