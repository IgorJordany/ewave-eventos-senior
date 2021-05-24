using System;
using System.Threading.Tasks;
using Eventos.Application.Queries.Funcionario;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/funcionarios")]
    public class FuncionarioController : ControllerBase
    {
        private readonly ObterFuncionarioHandler _obterFuncionarioHandler;

        public FuncionarioController(
            ObterFuncionarioHandler obterFuncionarioHandler)
        {
            _obterFuncionarioHandler = obterFuncionarioHandler;
        }

        [HttpGet("{funcionarioId}")]
        public async Task<ObterFuncionarioResponse> ObterFuncionario([FromRoute] Guid funcionarioId)
        {
            var response = await _obterFuncionarioHandler.Handle(new ObterFuncionarioRequest { FuncionarioId = funcionarioId });
            return response;
        }
    }
}