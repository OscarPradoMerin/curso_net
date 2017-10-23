using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Text;
using System.Web.Services.Description;
using MimeKit;
using Powerdede.Data;

namespace Powerdede.Services
{
    public class MailService : IMailService
    {
        public void SendMail(string receiver, string subject, string messageString, string alias)
        {
            // Connect to SMTP client with host and port (Gmail)
            var message = new MailMessage();
            var smtpClient = new SmtpClient(MailData.Host);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = MailData.Port;
            smtpClient.Credentials = new NetworkCredential(MailData.Address, MailData.Password);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryFormat = SmtpDeliveryFormat.International;

            // Create message
            message.From = new MailAddress(MailData.Address, alias);
            message.To.Add(receiver);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = messageString;

            // Send mail
            smtpClient.Send(message);
        }
    }
}