using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class Palestra : Entity
    {
        public Guid CategoriaId { get; }
        public string Tema { get; }
        public string Local { get; }
        public DateTime DataInicio { get; }
        public float Duracao { get; }
        public Funcionario Palestrante { get; }
        public ICollection<Participante> Participantes { get; } = new HashSet<Participante>();

        public Palestra(Guid categoriaId,
            string tema,
            string local,
            DateTime dataInicio,
            float duracao,
            Funcionario palestrante,
            ICollection<Participante> participantes)
        {
            CategoriaId = categoriaId;
            Tema = tema;
            Local = local;
            DataInicio = dataInicio;
            Duracao = duracao;
            Palestrante = palestrante;
            Participantes = participantes;
        }
    }
}
