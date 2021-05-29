using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.Palestra
{
    public class ObterPalestraResponse
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string Tema { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public float Duracao { get; set; }
        public Guid PalestranteId { get; set; }
        public List<ParticipantesResponseDto> Participadores { get; set; }
    }

    public class ParticipantesResponseDto
    {
        public Guid ParticipanteId { get; set; }
        public Guid FuncionarioId { get; set; }
        public bool Confirmou { get; set; }
    }
}