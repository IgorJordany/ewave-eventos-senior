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
        private readonly ObterFuncionariosHandler _obterFuncionariosHandler;

        public FuncionarioController(
            ObterFuncionarioHandler obterFuncionarioHandler,
            ObterFuncionariosHandler obterFuncionariosHandler)
        {
            _obterFuncionarioHandler = obterFuncionarioHandler;
            _obterFuncionariosHandler = obterFuncionariosHandler;
        }

        [HttpGet("{funcionarioId}")]
        public async Task<ObterFuncionarioResponse> ObterFuncionario([FromRoute] Guid funcionarioId)
        {
            var response = await _obterFuncionarioHandler.Handle(new ObterFuncionarioRequest { FuncionarioId = funcionarioId });
            return response;
        }

        [HttpGet("")]
        public async Task<ObterFuncionariosResponse> ObterFuncionarios([FromRoute] Guid funcionarioId)
        {
            var response = await _obterFuncionariosHandler.Handle(new ObterFuncionariosRequest());
            return response;
        }
    }
}