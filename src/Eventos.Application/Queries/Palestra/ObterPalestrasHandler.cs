using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Palestra
{
    public class ObterPalestrasHandler : IQueryHandler<ObterPalestrasRequest, ObterPalestrasResponse>
    {
        private readonly IPalestraRepository _palestraRepository;

        public ObterPalestrasHandler(IPalestraRepository palestraRepository)
        {
            _palestraRepository = palestraRepository;
        }

        public async Task<ObterPalestrasResponse> Handle(ObterPalestrasRequest request)
        {
            var palestra = await _palestraRepository.ObterListaPalestras();

            return new ObterPalestrasResponse
            {
                Palestras = palestra.Select(p => new Palestra
                {
                    CategoriaId = p.CategoriaId,
                    Tema = p.Tema,
                    Local = p.Local,
                    DataInicio = p.DataInicio,
                    Duracao = p.Duracao,
                    PalestranteId = p.PalestranteId,
                    Participadores = p.Participantes.Select(pe => new ParticipadoresDto
                    {
                        FuncionarioId = pe.FuncionarioId,
                        Confirmou = pe.Confirmou
                    }).ToList()
                }).ToList()
                
            };
        }
    }
}