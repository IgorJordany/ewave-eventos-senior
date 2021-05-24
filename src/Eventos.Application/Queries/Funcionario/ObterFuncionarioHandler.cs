using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Funcionario
{
    public class ObterFuncionarioHandler : IQueryHandler<ObterFuncionarioRequest, ObterFuncionarioResponse>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ObterFuncionarioHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ObterFuncionarioResponse> Handle(ObterFuncionarioRequest request)
        {
            var funcionario = await _funcionarioRepository.ObterFuncionarioPorId(request.FuncionarioId);

            return new ObterFuncionarioResponse
            { 
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf,
                DataNascimento = funcionario.DataNascimento
            };
        }
    }
}