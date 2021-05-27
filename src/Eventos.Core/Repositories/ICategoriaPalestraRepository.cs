using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface ICategoriaPalestraRepository
    {
        Task Incluir(CategoriaPalestra categoriaPalestra);
        Task<List<CategoriaPalestra>> ObterListaCategoriaPalestras();
        Task<CategoriaPalestra> ObterCategoriaPalestraPorId(Guid id);
    }
}