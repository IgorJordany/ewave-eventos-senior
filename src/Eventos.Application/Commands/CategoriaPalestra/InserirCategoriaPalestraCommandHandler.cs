using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Commands.CategoriaPalestra
{
    public class InserirCategoriaPalestraCommandHandler : ICommandHandler<InserirCategoriaPalestraCommand, InserirCategoriaPalestraResponse>
    {
        private readonly ICategoriaPalestraRepository _categoriaPalestraRepository;

        public InserirCategoriaPalestraCommandHandler(
            ICategoriaPalestraRepository categoriaPalestraRepository)
        {
            _categoriaPalestraRepository = categoriaPalestraRepository;
        }

        public async Task<InserirCategoriaPalestraResponse> Handler(InserirCategoriaPalestraCommand command)
        {
            var categoriaPalestra = new Core.Entities.CategoriaPalestra(command.Nome);
            await _categoriaPalestraRepository.Incluir(categoriaPalestra);

            return new InserirCategoriaPalestraResponse
            {
                CategoriaPalestraId = categoriaPalestra.Id
            };
        }
    }
}