using Eventos.Core.Entities;
using Eventos.Shared.Utilities;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Eventos.WebApi.Tests.Entities
{
    public class FuncionarioTests
    {
        [Theory]
        [InlineData("João", "55302552051")]
        [InlineData("Jorge","586.837.930-60")]
        [InlineData("Maria","397.081.630-07")]
        [InlineData("Fernanda","09202093008")]
        public void Deve_criar_funcionario(string nome, string cpf)
        {
            var cpfValido = new CPF(cpf);
            var nascimento = DateTime.Now;
            var funcionario = new Funcionario(nome, cpfValido.Cpf, nascimento);

            using (new AssertionScope())
            {
                funcionario.Notifications.Any().Should().BeFalse();

                funcionario.Cpf.Should().Be(cpfValido.Cpf);
                funcionario.Nome.Should().Be(nome);
                funcionario.DataNascimento.Should().Be(nascimento);
            }
        }
    }
}
