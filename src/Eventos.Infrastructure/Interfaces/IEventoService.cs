using System;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Interfaces
{
    public interface IEventoService
    {
        Task NotificarConfirmacaoPresenta(Guid eventoId);
    }
}
