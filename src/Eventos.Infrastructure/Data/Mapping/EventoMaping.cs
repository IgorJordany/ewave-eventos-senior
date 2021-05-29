using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class EventoMaping
    {
        public EventoMaping(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.DataInicio)
               .HasColumnName("DataInicio")
               .IsRequired();

            builder.Property(c => c.DataFim)
               .HasColumnName("DataFim")
               .IsRequired();

            builder.Property(c => c.JobId)
                .HasColumnName("JobId");

            builder
                .HasMany(i => i.Palestras)
                .WithOne()
                .HasForeignKey(p => p.EventoId);
        }
    }
}