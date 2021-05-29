using System;
using System.Threading.Tasks;
using Eventos.Application.Commands.EmailTest;
using Eventos.Application.Commands.Palestra;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Abstractions;
using Eventos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/palestra")]
    public class PalestraController : ControllerBase
    {
        private readonly InserirPalestraCommandHandler _inserirPalestraCommandHandler;
        private readonly IUow _uow;
        private readonly EmailTestCommandHandler _emailTestCommandHandler;

        public PalestraController(InserirPalestraCommandHandler inserirPalestraCommandHandler,
            IUow uow,
            EmailTestCommandHandler emailTestCommandHandler)
        {
            _inserirPalestraCommandHandler = inserirPalestraCommandHandler;
            _uow = uow;
            _emailTestCommandHandler = emailTestCommandHandler;
        }

        [HttpPost("inserir")]
        public async Task<InserirPalestraResponse> InserirPalestra([FromBody] InserirPalestraCommand command)
        {
            var response = await _inserirPalestraCommandHandler.Handler(command);

            _uow.Commit();

            return response;
        }

        [HttpPost("{palestraId}")]
        public async Task<EmailTestResponse> Teste([FromRoute] Guid palestraId)
        {
            var response = await _emailTestCommandHandler.Handler(new EmailTestCommand { PalestraId = palestraId});

            _uow.Commit();

            return response;
        }
    }
}