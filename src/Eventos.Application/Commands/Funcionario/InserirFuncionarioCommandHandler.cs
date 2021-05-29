using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Commands.Base;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using Eventos.Shared.Utilities;

namespace Eventos.Application.Commands.Funcionario
{
    public class InserirFuncionarioCommandHandler : ICommandHandler<InserirFuncionarioCommand, InserirFuncionarioResponse>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public InserirFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<InserirFuncionarioResponse> Handler(InserirFuncionarioCommand command)
        {
            var cpf = new CPF(command.Cpf);
            var email = new Email(command.Email);

            var funcionario = new Core.Entities.Funcionario(
                command.Nome,
                cpf.Cpf,
                command.DataNascimento,
                email.EmailValido);

            await _funcionarioRepository.Incluir(funcionario);


            return new InserirFuncionarioResponse { FuncionarioId = funcionario.Id };
        }
    }
}