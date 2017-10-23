using System.Web.Services.Description;

namespace Powerdede.Services
{
    public interface IMailService
    {
        void SendMail(string receiver, string subject, string messageString, string alias);
    }
}
