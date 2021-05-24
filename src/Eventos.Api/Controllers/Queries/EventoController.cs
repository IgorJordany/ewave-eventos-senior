using System.Threading.Tasks;
using Eventos.Application.Commands.Funcionario;
using Eventos.Application.Queries.Evento;
using Eventos.Application.Queries.Funcionario;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly ObterEventosHandler _obterEventosHandler;

        public EventoController(ObterEventosHandler obterEventosHandler)
        {
            _obterEventosHandler = obterEventosHandler;
        }

        [HttpGet("")]
        public async Task<ObterEventosResponse> ObterEventos()
        {
            var response = await _obterEventosHandler.Handle(new ObterEventosRequest());
            return response;
        }
    }
}