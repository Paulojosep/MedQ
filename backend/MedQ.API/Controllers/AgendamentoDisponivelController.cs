using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoDisponivelController : ControllerBase
    {
        private readonly IAgendamentoDisponivelService _service;

        public AgendamentoDisponivelController(IAgendamentoDisponivelService service)
        {
            _service = service;
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamentoDisponivel = await _service.GetById(id);
            if (agendamentoDisponivel.Equals(null)) return NotFound("Agendamento Disponivel Não Econtrado");
            return Ok(agendamentoDisponivel);
        }

        [HttpGet("PorEstabelecimento")]
        public async Task<IActionResult> GetByEstabelecimento(int estabelecimentoId)
        {
            var agendamentoDisponivel = await _service.GetByEstabelecimento(estabelecimentoId);
            if (agendamentoDisponivel.Count.Equals(0)) return NotFound("Agendamento Disponivel Não Econtrado");
            return Ok(agendamentoDisponivel);
        }

        [HttpGet("Status")]
        public async Task<IActionResult> GetByStatus(int establelcimentoId)
        {
            var agendamentoDisponivel = await _service.GetByStatus(establelcimentoId);
            if (agendamentoDisponivel.Count.Equals(0)) return NotFound("Agendamento Disponivel Não Econtrado");
            return Ok(agendamentoDisponivel);
        }

        [HttpPost]
        public async Task<IActionResult> GetAgendamentoDisponivel([FromBody] AgendamentoDisponivelInput input)
        {
            var agendamentoDisponivel = await _service.GetAgendamentoDisponivel(input);
            if (agendamentoDisponivel.Count.Equals(0)) return NotFound("Agendamento Disponivel Não Econtrado");
            return Ok(agendamentoDisponivel);
        }
    }
}
