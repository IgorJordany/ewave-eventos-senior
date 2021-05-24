using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class CategoriaPalestraMaping
    {
        public CategoriaPalestraMaping(EntityTypeBuilder<CategoriaPalestra> builder)
        {
            builder.ToTable("CategoriaPalestra");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
