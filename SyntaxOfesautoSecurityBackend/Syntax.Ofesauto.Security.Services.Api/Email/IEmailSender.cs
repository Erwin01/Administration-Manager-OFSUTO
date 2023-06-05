using System.Threading.Tasks;

namespace Syntax.Ofesauto.Security.Services.Api.Email
{
    public interface IEmailSender
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }
}
