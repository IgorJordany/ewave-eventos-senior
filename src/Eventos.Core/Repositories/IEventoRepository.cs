using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface IEventoRepository
    {
        Task Incluir(Evento evento);
        Task<List<Evento>> ObterListaEventos();
        Task<Evento> ObterEventoPorId(Guid id);
    }
}