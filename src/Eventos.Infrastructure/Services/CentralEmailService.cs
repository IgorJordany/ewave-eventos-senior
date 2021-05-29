using Eventos.Core.Entities;
using Eventos.Infrastructure.Interfaces;
using System;
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
        /*
        public bool EnviarEmails(string email)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("EMAIL DO REMETENTE");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Teste Thiago";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "<b>Olá Tudo bem ??</b><p>Teste Parágrafo</p>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("EMAIL DO REMETENTE", "SUA SENHA AQUI");

                _smtpClient.EnableSsl = true;

                _smtpClient.SendMailAsync(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/

        public void EnviarEmailsLocalPalestra(Palestra palestra)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("eventostestesenior@gmail.com", "TrampoTeste"),
                    EnableSsl = true,
                };

                foreach (var item in palestra.Participantes)
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("eventostestesenior@gmail.com"),
                        Subject = "Lembrete palestra " + palestra.Tema,
                        Body = "<h1>Hello</h1>",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(item.Funcionario.Email);

                    smtpClient.Send(mailMessage);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
