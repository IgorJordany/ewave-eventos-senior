using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.Palestra
{
    public class ObterPalestrasResponse
    {
        public List<Palestra> Palestras { get; set; }
    }

    public class Palestra
    {
        public Guid CategoriaId { get; set; }
        public string Tema { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public float Duracao { get; set; }
        public Guid PalestranteId { get; set; }
        public List<ParticipadoresDto> Participadores { get; set; }
    }
}