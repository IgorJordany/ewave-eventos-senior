using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class EventoFuncionario : Entity
    {
        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
