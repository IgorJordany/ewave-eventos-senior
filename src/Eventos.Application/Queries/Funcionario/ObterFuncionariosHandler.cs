using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Queries.Base;
using Eventos.Core.Repositories;

namespace Eventos.Application.Queries.Funcionario
{
    public class ObterFuncionariosHandler : IQueryHandler<ObterFuncionariosRequest, ObterFuncionariosResponse>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ObterFuncionariosHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ObterFuncionariosResponse> Handle(ObterFuncionariosRequest request)
        {
            var funcionario = await _funcionarioRepository.ObterListaFuncionarios();

            return new ObterFuncionariosResponse
            { 
                Funcionarios = funcionario.Select(f => new FuncionarioDto { 
                    Nome = f.Nome,
                    DataNascimento = f.DataNascimento,
                    Cpf = f.Cpf,
                    Id = f.Id,
                    Email = f.Email
                })
            };
        }
    }
}