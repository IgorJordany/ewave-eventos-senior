using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventosResponse
    {
        public IEnumerable<Evento> Eventos { get; set; }
    }

    public class Evento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<Organizador> Organizadores { get; set; }
    }

    public class Organizador
    {
        public Guid FuncionarioId { get; set; }
        public string Nome { get; set; }
    }
}