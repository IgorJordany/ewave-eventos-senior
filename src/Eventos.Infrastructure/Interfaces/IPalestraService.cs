using System;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Interfaces
{
    public interface IPalestraService
    {
        Task NotificarLocalPalestra(Guid palestraId);
    }
}
