using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Eventos.Infrastructure.Services
{
    public class CentralEmailService : ICentralEmailService
    {
        public CentralEmailService()
        {
        }

        public void EnviarEmails(List<string> emails, EmailContent content)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("eventostestesenior@gmail.com", "TrampoTeste"),
                EnableSsl = true,
            };

            foreach (var item in emails)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("eventostestesenior@gmail.com"),
                    Subject = content.Subject,
                    Body = content.Body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(item);

                smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
     public class EmailContent
    {
        public string Subject { get; }
        public string Body { get; }

        public EmailContent(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
