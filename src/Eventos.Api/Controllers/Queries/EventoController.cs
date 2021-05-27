using System;
using System.Threading.Tasks;
using Eventos.Application.Queries.Evento;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly ObterEventosHandler _obterEventosHandler;
        private readonly ObterEventoHandler _obterEventoHandler;

        public EventoController(ObterEventosHandler obterEventosHandler,
            ObterEventoHandler obterEventoHandler)
        {
            _obterEventosHandler = obterEventosHandler;
            _obterEventoHandler = obterEventoHandler;
        }

        [HttpGet("")]
        public async Task<ObterEventosResponse> ObterEventos()
        {
            var response = await _obterEventosHandler.Handle(new ObterEventosRequest());
            return response;
        }

        [HttpGet("{funcionarioId}")]
        public async Task<ObterEventoResponse> ObterEvento([FromRoute] Guid eventoId)
        {
            var response = await _obterEventoHandler.Handle(new ObterEventoRequest());
            return response;
        }
    }
}