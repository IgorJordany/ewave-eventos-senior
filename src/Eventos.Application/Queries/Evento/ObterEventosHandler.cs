using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventosHandler : IQueryHandler<ObterEventosRequest, ObterEventosResponse>
    {
        private readonly IEventoRepository _eventoRepository;

        public ObterEventosHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<ObterEventosResponse> Handle(ObterEventosRequest request)
        {
            var eventos = await _eventoRepository.ObterListaEventos();

            return new ObterEventosResponse
            {
                Eventos = eventos.Select(e => new Evento
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    DataFim = e.DataFim,
                    DataInicio = e.DataInicio,
                    Organizadores = e.Organizadores.Select(o => new Organizador
                    {
                        Nome = o.Funcionario.Nome,
                        FuncionarioId = o.FuncionarioId
                    })
                })
            };
        }
    }
}