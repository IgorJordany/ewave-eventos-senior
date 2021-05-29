using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Application.Commands.Funcionario;
using Eventos.Application.Commands.Palestra;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using Hangfire;

namespace Eventos.Application.Commands.EmailTest
{
    public class EmailTestCommandHandler : ICommandHandler<EmailTestCommand, EmailTestResponse>
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly ICategoriaPalestraRepository _categoriaPalestraRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICentralEmailService _centralEmailService;

        public EmailTestCommandHandler(
            IPalestraRepository palestraRepository,
            ICategoriaPalestraRepository categoriaPalestraRepository,
            IFuncionarioRepository funcionarioRepository,
            ICentralEmailService centralEmailService)
        {
            _palestraRepository = palestraRepository;
            _categoriaPalestraRepository = categoriaPalestraRepository;
            _funcionarioRepository = funcionarioRepository;
            _centralEmailService = centralEmailService;
        }

        public async Task<EmailTestResponse> Handler(EmailTestCommand command)
        {
            //var palestra = await _palestraRepository.ObterPalestraPorId(command.PalestraId);
            //_centralEmailService.EnviarEmailsLocalPalestra(palestra);

            var jobId = BackgroundJob.Enqueue<ICentralEmailService>(
              s => s.EnviarEmailsLocalPalestra(command.PalestraId)
            );
            //BackgroundJob.Delete(notification.JobId);

            return new EmailTestResponse();
        }
    }
}