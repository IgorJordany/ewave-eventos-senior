using Eventos.Core.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit;

namespace Eventos.WebApi.Tests.Entities
{
    public class ParticipanteTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Deve_confirmar_participante_palestra(bool confirmou)
        {
            var participante = new Participante(Guid.NewGuid(), Guid.NewGuid());

            participante.Confirmar(confirmou);
          
            using (new AssertionScope())
            {
                participante.Confirmou.Should().Be(confirmou);
            }
        }
    }

}
