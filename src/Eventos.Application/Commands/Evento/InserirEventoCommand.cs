using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Evento
{
    public class InserirEventoCommand : ICommand<InserirEventoResponse>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public List<OrganizadoresDto> Organizadores { get; set; }
    }

    public class OrganizadoresDto
    {
        public Guid FuncionarioId { get; set; }
    }
}