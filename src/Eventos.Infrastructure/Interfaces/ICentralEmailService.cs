using Eventos.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Interfaces
{
    public interface ICentralEmailService
    {
        void EnviarEmails(List<string> emails, EmailContent content);
    }
}
