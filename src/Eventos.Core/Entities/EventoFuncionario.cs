using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class EventoFuncionario : Entity
    {
        public Guid EventoId { get; }
        public Evento Evento { get; }
        public Guid FuncionarioId { get; }
        public Funcionario Funcionario { get; }

        public EventoFuncionario(Guid eventoId, Guid funcionarioId)
        {
            EventoId = eventoId;
            FuncionarioId = funcionarioId;
        }
    }
}
