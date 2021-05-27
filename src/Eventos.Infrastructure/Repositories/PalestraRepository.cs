using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    public class PalestraRepository : IPalestraRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PalestraRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Incluir(Palestra palestra)
        {
            await _databaseContext.Palestras.AddAsync(palestra);
        }

        public Task<List<Palestra>> ObterListaPalestras()
        {
            return _databaseContext.Palestras
                .Include(e => e.Participantes)
                .ThenInclude(c => c.Funcionario)
                .ToListAsync();
        }

        public Task<Palestra> ObterPalestraPorId(Guid id)
        {
            return _databaseContext.Palestras
                .Include(e => e.Participantes)
                .ThenInclude(c => c.Funcionario)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
