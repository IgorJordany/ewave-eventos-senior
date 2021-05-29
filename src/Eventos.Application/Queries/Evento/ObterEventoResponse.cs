using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<Organizador> Organizadores { get; set; }
    }
}