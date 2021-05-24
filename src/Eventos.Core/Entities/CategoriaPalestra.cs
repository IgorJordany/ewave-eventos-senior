using Eventos.Shared.Entities;

namespace Eventos.Core.Entities
{
    public class CategoriaPalestra : Entity
    {
        public string Nome { get; }

        public CategoriaPalestra(string nome)
        {
            Nome = nome;
        }
    }
}
