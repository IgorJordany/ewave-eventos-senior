using Eventos.Shared.Utilities;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Eventos.WebApi.Tests.Utilities
{
    public class CpfTests
    {
        [Theory]
        [InlineData("55302552051")]
        [InlineData("586.837.930-60")]
        [InlineData("397.081.630-07")]
        [InlineData("09202093008")]
        public void Deve_criar_cpfs_valido(string cpf)
        {
            var cpfValidado = new CPF(cpf);

            using (new AssertionScope())
            {
                cpfValidado.Notifications.Any().Should().BeFalse();

                cpfValidado.Cpf.Should().NotBeNullOrEmpty();
            }
        }

        [Theory]
        [InlineData("4312351451346")]
        [InlineData("586.837.930-5134513460")]
        [InlineData("397.0123413481.630-07")]
        [InlineData("0920214513454093008")]
        [InlineData("8")]
        [InlineData("0")]
        [InlineData("fajklhfkewqefçwemf")]
        public void Deve_negar_cpfs_invalidos(string cpf)
        {
            var cpfValidado = new CPF(cpf);

            using (new AssertionScope())
            {
                cpfValidado.Notifications.Any().Should().BeTrue();
            }
        }
    }
}
