using Eventos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infrastructure.Data.Mapping
{
    public class EventoFuncionarioMaping
    {
        public EventoFuncionarioMaping(EntityTypeBuilder<EventoFuncionario> builder)
        {
            builder.ToTable("EventoFuncionario");

            builder.HasKey(c => c.Id);

            builder
                .HasOne(ef => ef.Evento)
                .WithMany(e => e.Organizadores)
                .HasForeignKey(ef => ef.EventoId);

            builder
                .HasOne(ef => ef.Funcionario)
                .WithMany(e => e.Eventos)
                .HasForeignKey(ef => ef.FuncionarioId);
        }
    }
}