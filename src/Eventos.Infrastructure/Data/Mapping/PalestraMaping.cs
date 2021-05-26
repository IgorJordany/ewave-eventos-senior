using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class PalestraMaping
    {
        public PalestraMaping(EntityTypeBuilder<Palestra> builder)
        {
            builder.ToTable("Palestra");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoriaId)
               .HasColumnName("CategoriaId")
               .IsRequired();

            builder.Property(c => c.Tema)
               .HasColumnName("Tema")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(c => c.Local)
               .HasColumnName("Local")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(c => c.DataInicio)
               .HasColumnName("DataInicio")
               .IsRequired();

            builder.Property(c => c.Duracao)
                .HasColumnName("Duracao")
                .IsRequired();
        }
    }
}