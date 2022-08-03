using IUDApplication.Models;
using System.Threading.Tasks;

namespace IUDApplication.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
    }
}