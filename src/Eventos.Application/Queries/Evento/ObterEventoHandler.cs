using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventoHandler : IQueryHandler<ObterEventoRequest, ObterEventoResponse>
    {
        private readonly IEventoRepository _eventoRepository;

        public ObterEventoHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<ObterEventoResponse> Handle(ObterEventoRequest request)
        {
            var evento = await _eventoRepository.ObterEventoPorId(request.EventoId);

            return new ObterEventoResponse
            {
                Nome = evento.Nome,
                DataFim = evento.DataFim,
                DataInicio = evento.DataInicio,
                Organizadores = evento.Organizadores.Select(o => new Organizador
                {
                    Nome = o.Funcionario.Nome,
                    FuncionarioId = o.FuncionarioId
                })
            };
        }
    }
}