using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.Funcionario
{
    public class ObterFuncionariosResponse
    {
        public IEnumerable<FuncionarioDto> Funcionarios { get; set; }
    }

    public class FuncionarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}