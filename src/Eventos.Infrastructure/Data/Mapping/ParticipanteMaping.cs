using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class ParticipanteMaping
    {
        public ParticipanteMaping(EntityTypeBuilder<Participante> builder)
        {
            builder.ToTable("Participante");

            builder.HasKey(c => c.Id);

            builder
                .HasOne(ef => ef.Palestra)
                .WithMany(e => e.Participantes)
                .HasForeignKey(ef => ef.PalestraId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ef => ef.Funcionario)
                .WithMany(e => e.Participantes)
                .HasForeignKey(ef => ef.FuncionarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(c => c.Confirmou)
               .HasColumnName("Confirmou")
               .IsRequired();
        }
    }
}