using System.Threading.Tasks;
using Eventos.Application.Commands.Funcionario;
using Eventos.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly InserirFuncionarioCommandHandler _inserirFuncionarioCommandHandler;
        private readonly IUow _uow;

        public FuncionarioController(InserirFuncionarioCommandHandler inserirFuncionarioCommandHandler,
            IUow uow)
        {
            _inserirFuncionarioCommandHandler = inserirFuncionarioCommandHandler;
            _uow = uow;
        }

        [HttpPost("inserir")]
        public async Task<InserirFuncionarioResponse> InserirItem([FromBody] InserirFuncionarioCommand command)
        {
            var response = await _inserirFuncionarioCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }
    }
}