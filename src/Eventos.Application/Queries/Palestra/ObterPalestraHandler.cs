using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Palestra
{
    public class ObterPalestraHandler : IQueryHandler<ObterPalestraRequest, ObterPalestraResponse>
    {
        private readonly IPalestraRepository _palestraRepository;

        public ObterPalestraHandler(IPalestraRepository palestraRepository)
        {
            _palestraRepository = palestraRepository;
        }

        public async Task<ObterPalestraResponse> Handle(ObterPalestraRequest request)
        {
            var palestra = await _palestraRepository.ObterPalestraPorId(request.PalestraId);

            return new ObterPalestraResponse
            {
                Id = palestra.Id,
                CategoriaId = palestra.CategoriaId,
                Tema = palestra.Tema,
                Local = palestra.Local,
                DataInicio = palestra.DataInicio,
                Duracao = palestra.Duracao,
                PalestranteId = palestra.PalestranteId,
                Participadores = palestra.Participantes.Select(p => new ParticipantesResponseDto
                {
                    ParticipanteId = p.Id,
                    FuncionarioId = p.FuncionarioId,
                    Confirmou = p.Confirmou
                }).ToList()
            };
        }
    }
}