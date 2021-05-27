using System;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Queries.Base;

namespace Eventos.Application.Queries.Palestra
{
    public class ObterPalestraRequest : IRequest<ObterPalestraResponse>
    {
        [Required]
        public Guid PalestraId { get; set; }
    }
}