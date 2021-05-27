using System.Threading.Tasks;
using Eventos.Application.Commands.Evento;
using Eventos.Application.Commands.Palestra;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/palestra")]
    public class PalestraController : ControllerBase
    {
        private readonly InserirEventoCommandHandler _inserirEventoCommandHandler;
        private readonly IUow _uow;

        public PalestraController(InserirEventoCommandHandler inserirEventoCommandHandler,
            IUow uow)
        {
            _inserirEventoCommandHandler = inserirEventoCommandHandler;
            _uow = uow;
        }

        [HttpPost("inserir")]
        public async Task<InserirEventoResponse> InserirEvento([FromBody] InserirEventoCommand command)
        {
            var response = await _inserirEventoCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }
    }
}