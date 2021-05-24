using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface IEventoFuncionarioRepository
    {
        Task Incluir(EventoFuncionario eventoFuncionario);
        Task<List<EventoFuncionario>> ObterListaEventoFuncionarios();
        Task<EventoFuncionario> ObterEventoFuncionarioPorId(Guid id);
    }
}