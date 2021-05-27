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
            throw new NotImplementedException();
        }

        public Task<Palestra> ObterPalestraPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
