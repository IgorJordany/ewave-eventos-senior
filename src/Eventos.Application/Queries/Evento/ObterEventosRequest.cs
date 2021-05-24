using System;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Queries.Base;

namespace Eventos.Application.Queries.Evento
{
    public class ObterEventosRequest : IRequest<ObterEventosResponse>
    {
        [Required]
        public Guid FuncionarioId { get; set; }
    }
}