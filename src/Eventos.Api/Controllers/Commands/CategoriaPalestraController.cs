using System.Threading.Tasks;
using Eventos.Application.Commands.CategoriaPalestra;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/categoria-palestra")]
    public class CategoriaPalestraController : ControllerBase
    {
        private readonly InserirCategoriaPalestraCommandHandler _inserirCategoriaPalestraCommandHandler;
        private readonly IUow _uow;

        public CategoriaPalestraController(InserirCategoriaPalestraCommandHandler inserirCategoriaPalestraCommandHandler,
            IUow uow)
        {
            _inserirCategoriaPalestraCommandHandler = inserirCategoriaPalestraCommandHandler;
            _uow = uow;
        }

        [HttpPost("inserir")]
        public async Task<InserirCategoriaPalestraResponse> InserirCategoriaPalestra([FromBody] InserirCategoriaPalestraCommand command)
        {
            var response = await _inserirCategoriaPalestraCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }
    }
}