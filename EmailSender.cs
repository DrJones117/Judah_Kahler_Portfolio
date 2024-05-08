using System.Net;
using System.Net.Mail;

namespace Judah_Kahler_Portfolio
{
    public class EmailSender :  IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "@gmail.com";
            var pw = "Password";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: email,
                subject,
                message));
        }
    }
}