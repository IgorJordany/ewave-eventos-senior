using Eventos.Core.Entities;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Interfaces
{
    public interface ICentralEmailService
    {
        void EnviarEmailsLocalPalestra(Palestra palestra);
    }
}
