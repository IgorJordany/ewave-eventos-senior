using System;

namespace Eventos.Application.Queries.Funcionario
{
    public class ObterFuncionarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
    }
}