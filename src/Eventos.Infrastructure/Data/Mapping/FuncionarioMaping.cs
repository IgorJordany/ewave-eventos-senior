using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class FuncionarioMaping
    {
        public FuncionarioMaping(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .IsRequired();
        }
    }
}