using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Participante
{
    public class ConfirmarParticipantesCommand : ICommand<ConfirmarParticipantesResponse>
    {
        public Guid PalestraId { get; set; }
        public List<ParticipantesCommandDto> Participantes { get; set; }
    }

    public class ParticipantesCommandDto
    {
        [Required]
        public Guid ParticipanteId { get; set; }
        [Required]
        public bool Confirmou { get; set; }
    }
}