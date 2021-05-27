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
    public class PalestraTests
    {
        private Funcionario FuncionarioGenerator()
        {
            var cpfValido = new CPF("55302552051");
            var nascimento = DateTime.Now;

            return new Funcionario("João", cpfValido.Cpf, nascimento);
        }

        [Fact]
        public void Deve_criar_palestra_com_sucesso()
        {
            var categoria = new CategoriaPalestra("Análise de Sistemas");
            var palestrante = FuncionarioGenerator();
            var dataInicio = DateTime.Now.AddDays(1);

            var palestra = new Palestra(categoria.Id, "Análise de sistemas", "Jabuticaba", dataInicio, 2, palestrante.Id);

            using (new AssertionScope())
            {
                palestra.CategoriaId.Should().Be(categoria.Id);
                palestra.PalestranteId.Should().Be(palestrante.Id);
                palestra.DataInicio.Should().Be(dataInicio);
            }
        }

        [Theory]
        [InlineData(40)]
        [InlineData(32)]
        [InlineData(21)]
        [InlineData(35)]
        public void Nao_deve_Adicionar_mais_de_vinte_participantes(int quantParticipantes)
        {
            var categoria = new CategoriaPalestra("Análise de Sistemas");
            var palestrante = FuncionarioGenerator();
            var dataInicio = DateTime.Now.AddDays(1);
            var participantes = new HashSet<Participante>();

            var palestra = new Palestra(categoria.Id, "Análise de sistemas", "Jabuticaba", dataInicio, 2, palestrante.Id);

            for (int i = 0; i < quantParticipantes; i++)
            {
                var part = FuncionarioGenerator();
                participantes.Add(new Participante(palestra.Id, part.Id, false));
            }

            Action act = () => palestra.AdicionarParticipantes(participantes);

            using (new AssertionScope())
            {
                act.Should().Throw<Exception>();
            }
        }
    }

}
