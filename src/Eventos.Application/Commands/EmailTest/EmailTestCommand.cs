using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.EmailTest
{
    public class EmailTestCommand : ICommand<EmailTestResponse>
    {
        [Required]
        public Guid PalestraId { get; set; }
    }
}