using MedQ.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEstabelecimentoController : ControllerBase
    {
        private readonly ITipoEstabelecimentoService _tipoEstabelecimentoService;

        public TipoEstabelecimentoController(ITipoEstabelecimentoService tipoEstabelecimentoService)
        {
            _tipoEstabelecimentoService = tipoEstabelecimentoService;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> GetAll()
        {
            var resultado = await _tipoEstabelecimentoService.ListaTipoEstabelecimentos();
            if(resultado == null)
            {
                return NotFound("Tipos Estabelecimento Não Econtrado");
            }
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCodigo(int codigo)
        {
            var resultado = await _tipoEstabelecimentoService.TipoEstabelecimentoPorCodigo(codigo);
            if (resultado == null)
            {
                return NotFound("Tipo Estabelecimento Não Econtrado");
            }
            return Ok(resultado);
        }
    }
}
