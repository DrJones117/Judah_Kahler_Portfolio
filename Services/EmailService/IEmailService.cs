namespace Judah_Kahler_Portfolio.Services.EmailService
{
    public interface IEmailService{
        Task SendEmail(EmailDto request);
    }
}