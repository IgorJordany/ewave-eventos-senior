using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Services
{
    public class PalestraService : IPalestraService
    {
        private readonly IPalestraRepository _palestraRepository;
        private readonly ICentralEmailService _centralEmailService;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public PalestraService(IPalestraRepository palestraRepository,
            ICentralEmailService centralEmailService,
            IFuncionarioRepository funcionarioRepository)
        {
            _palestraRepository = palestraRepository;
            _centralEmailService = centralEmailService;
            _funcionarioRepository = funcionarioRepository;
        }


        public async Task NotificarLocalPalestra(Guid palestraId)
        {
            var palestra = await _palestraRepository.ObterPalestraPorId(palestraId);

            var palestrante = await _funcionarioRepository.ObterFuncionarioPorId(palestra.PalestranteId);

            var emails = new List<string>();

            emails.Add(palestrante.Email);

            emails.AddRange(palestra.Participantes.Select(p => p.Funcionario.Email));

            var content = new EmailContent("<h1>Lembrete Palestra: " + palestra.Tema + "</h1>",
                "<h1>Lembrete Palestra: " + palestra.Tema + "</h1>" +
                "<h2>Data/Hora: " + palestra.DataInicio + "</h2>" +
                "<h2>Local: " + palestra.Local + "</h2>");

            _centralEmailService.EnviarEmails(emails, content);

            palestra.RemoverJobId();
        }
    }
}
