using System.Threading.Tasks;
using Eventos.Application.Commands.Palestra;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/palestra")]
    public class PalestraController : ControllerBase
    {
        private readonly InserirPalestraCommandHandler _inserirPalestraCommandHandler;
        private readonly IUow _uow;

        public PalestraController(InserirPalestraCommandHandler inserirPalestraCommandHandler,
            IUow uow)
        {
            _inserirPalestraCommandHandler = inserirPalestraCommandHandler;
            _uow = uow;
        }

        [HttpPost("inserir")]
        public async Task<InserirPalestraResponse> InserirPalestra([FromBody] InserirPalestraCommand command)
        {
            var response = await _inserirPalestraCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }
    }
}