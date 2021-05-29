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
    public class EventoTests
    {
        private Funcionario FuncionarioGenerator()
        {
            var cpfValido = new CPF("55302552051");
            var nascimento = DateTime.Now;
            var email = new Email("test@teste.com");

            return new Funcionario("João", cpfValido.Cpf, nascimento, email.EmailValido);
        }

        [Theory]
        [InlineData("Jabuticaba")]
        [InlineData("Abacaxi")]
        [InlineData("Melao")]
        public void Nao_deve_criar_evento_com_data_fim_menor_ou_igual_data_inicio(string nome)
        {
            var organizadores = new List<Funcionario> { FuncionarioGenerator(), FuncionarioGenerator()};
            var dataFim = DateTime.Now;
            var dataInicio = dataFim.AddDays(1);

            Action act = () => new Evento(nome, dataInicio, dataFim);

            using (new AssertionScope())
            {
                act.Should().Throw<Exception>();
            }
        }
    }

}
