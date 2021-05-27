using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.CategoriaPalestra
{
    public class ObterCategoriaPalestrasHandler : IQueryHandler<ObterCategoriaPalestrasRequest, ObterCategoriaPalestrasResponse>
    {
        private readonly ICategoriaPalestraRepository _categoriaPalestraRepository;

        public ObterCategoriaPalestrasHandler(ICategoriaPalestraRepository categoriaPalestraRepository)
        {
            _categoriaPalestraRepository = categoriaPalestraRepository;
        }

        public async Task<ObterCategoriaPalestrasResponse> Handle(ObterCategoriaPalestrasRequest request)
        {
            var categoriaPalestras = await _categoriaPalestraRepository.ObterListaCategoriaPalestras();

            return new ObterCategoriaPalestrasResponse
            {
                CategoriaPalestras = categoriaPalestras.Select(f => new CategoriaPalestrasDto
                {
                    Nome = f.Nome,
                    Id = f.Id
                })
            };
        }
    }
}