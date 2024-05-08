namespace Judah_Kahler_Portfolio
{
    public  interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}