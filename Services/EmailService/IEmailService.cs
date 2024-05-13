using Judah_Kahler_Portfolio.Models;

namespace Judah_Kahler_Portfolio.Services.EmailService
{
    public interface IEmailService{
        void SendEmail(EmailDto request);
    }
}