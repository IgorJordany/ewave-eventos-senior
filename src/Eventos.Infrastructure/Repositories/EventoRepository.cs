using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EventoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Incluir(Evento evento)
        {
            await _databaseContext.Eventos.AddAsync(evento);
        }

        public Task<Evento> ObterEventoPorId(Guid id)
        {
            return _databaseContext.Eventos
                .Include(e => e.Organizadores)
                .ThenInclude(c => c.Funcionario)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Evento>> ObterListaEventos()
        {
            var eventos = _databaseContext.Eventos
                .Include(e => e.Organizadores)
                .ThenInclude(c=> c.Funcionario)
                .ToListAsync();

            return eventos;
        }
    }
}
