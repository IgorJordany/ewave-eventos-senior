using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ICentralEmailService _centralEmailService;

        public EventoService(IEventoRepository eventoRepository,
            ICentralEmailService centralEmailService)
        {
            _eventoRepository = eventoRepository;
            _centralEmailService = centralEmailService;
        }

        public async Task NotificarConfirmacaoPresenta(Guid eventoId)
        {
            var evento = await _eventoRepository.ObterEventoPorId(eventoId);

            var emails = new List<string>();

            emails.AddRange(evento.Organizadores.Select(f => f.Funcionario.Email));

            var content = new EmailContent("Lembrete Confirmar Presença no evento: " + evento.Nome,
                "<h1>Lembrete Confirmar Presença no evento: " + evento.Nome + "</h1>" +
                "<h2>Data/Hora: " + evento.DataInicio + "</h2>");

            _centralEmailService.EnviarEmails(emails, content);

            evento.RemoverJobId();
        }
    }
}
