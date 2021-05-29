using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Eventos.Core.Entities
{
    public class Palestra : Entity
    {
        public Guid EventoId { get; }
        public Guid CategoriaId { get; }
        public string Tema { get; }
        public string Local { get; }
        public DateTime DataInicio { get; }
        public float Duracao { get; }
        public Guid PalestranteId { get; }
        public string JobId { get; set; }
        public ICollection<Participante> Participantes { get; } = new HashSet<Participante>();

        public Palestra(Guid categoriaId,
            string tema,
            string local,
            DateTime dataInicio,
            float duracao,
            Guid palestranteId, Guid eventoId)
        {
            CategoriaId = categoriaId;
            Tema = tema;
            Local = local;
            DataInicio = dataInicio;
            Duracao = duracao;
            PalestranteId = palestranteId;
            EventoId = eventoId;
        }

        public void AdicionarJobId(string jobId)
        {
            JobId = jobId;
        }

        public void RemoverJobId()
        {
            JobId = null;
        }

        public void AdicionarParticipantes(ICollection<Participante> participantes)
        {
            if (20 - Participantes.Count < participantes.Count)
            {
                throw new Exception("Não pode inserir mais de vinte participantes");
            }

            foreach (var item in participantes)
            {
                Participantes.Add(item);
            }
        }
    }
}
