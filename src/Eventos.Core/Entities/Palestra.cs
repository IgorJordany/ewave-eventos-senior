using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Eventos.Core.Entities
{
    public class Palestra : Entity
    {
        public Guid CategoriaId { get; }
        public string Tema { get; }
        public string Local { get; }
        public DateTime DataInicio { get; }
        public float Duracao { get; }
        public Guid PalestranteId { get; }
        public ICollection<Participante> Participantes { get; } = new HashSet<Participante>();

        public Palestra(Guid categoriaId,
            string tema,
            string local,
            DateTime dataInicio,
            float duracao,
            Guid palestranteId)
        {
            CategoriaId = categoriaId;
            Tema = tema;
            Local = local;
            DataInicio = dataInicio;
            Duracao = duracao;
            PalestranteId = palestranteId;
        }

        public void AdicionarParticipantes(ICollection<Participante> participantes)
        {

        }
    }
}
