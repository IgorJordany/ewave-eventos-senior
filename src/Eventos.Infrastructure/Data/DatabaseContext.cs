using Eventos.Core.Entities;
using Eventos.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoFuncionario> EventoFuncionarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FuncionarioMaping(modelBuilder.Entity<Funcionario>());
            new EventoMaping(modelBuilder.Entity<Evento>());
            new EventoFuncionarioMaping(modelBuilder.Entity<EventoFuncionario>());
        }
    }
}