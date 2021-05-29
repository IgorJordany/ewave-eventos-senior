using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ParticipanteRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<List<Participante>> ObterParticipantesPorPalestraId(Guid palestraId)
        {
            return _databaseContext.Participantes
                .Where(p => p.PalestraId == palestraId)
                .ToListAsync();
        }
    }
}
