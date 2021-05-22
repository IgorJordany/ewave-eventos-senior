using Eventos.Core.Entities;
using Eventos.Infrastructure.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Funcionario> Funcionarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            new FuncionarioMaping(modelBuilder.Entity<Funcionario>());
        }
    }
}