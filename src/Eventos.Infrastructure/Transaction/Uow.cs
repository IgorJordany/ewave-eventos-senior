using Eventos.Infrastructure.Abstractions;
using Eventos.Infrastructure.Data;

namespace Eventos.Infrastructure.Transaction
{
    public class Uow : IUow
    {
        private readonly DatabaseContext _context;

        public Uow(DatabaseContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}