using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface IParticipanteRepository
    {
        Task<List<Participante>> ObterParticipantesPorPalestraId(Guid palestraId);
    }
}