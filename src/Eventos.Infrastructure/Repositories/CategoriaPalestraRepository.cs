using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;

namespace Eventos.Infrastructure.Repositories
{
    public class CategoriaPalestraRepository : ICategoriaPalestraRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriaPalestraRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Incluir(CategoriaPalestra categoriaPalestra)
        {
            await _databaseContext.CategoriaPalestras.AddAsync(categoriaPalestra);
        }

        public Task<CategoriaPalestra> ObterCategoriaPalestraPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoriaPalestra>> ObterListaCategoriaPalestras()
        {
            throw new NotImplementedException();
        }
    }
}
