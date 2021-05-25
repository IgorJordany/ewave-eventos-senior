using Eventos.Shared.Entities;
using System.Collections.Generic;

namespace Eventos.Core.Entities
{
    public class CategoriaPalestra : Entity
    {
        public string Nome { get; }
        public ICollection<Palestra> Palestras { get; } = new HashSet<Palestra>();

        public CategoriaPalestra(string nome)
        {
            Nome = nome;
        }
    }
}
