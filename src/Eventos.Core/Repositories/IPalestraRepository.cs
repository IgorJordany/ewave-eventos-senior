using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface IPalestraRepository
    {
        Task Incluir(Palestra palestra);
        Task<List<Palestra>> ObterListaPalestras();
        Task<Palestra> ObterPalestraPorId(Guid id);
    }
}