using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    public class EventoFuncionarioRepository : IEventoFuncionarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EventoFuncionarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Incluir(EventoFuncionario eventoFuncionario)
        {
            await _databaseContext.EventoFuncionarios.AddAsync(eventoFuncionario);
        }

        public Task<EventoFuncionario> ObterEventoFuncionarioPorId(Guid id)
        {
            return _databaseContext.EventoFuncionarios.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<EventoFuncionario>> ObterListaEventoFuncionarios()
        {
            return _databaseContext.EventoFuncionarios.ToListAsync();
        }
    }
}
