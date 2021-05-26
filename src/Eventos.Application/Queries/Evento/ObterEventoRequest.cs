using System;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Queries.Base;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventoRequest : IRequest<ObterEventoResponse>
    {
        [Required]
        public Guid EventoId { get; set; }
    }
}