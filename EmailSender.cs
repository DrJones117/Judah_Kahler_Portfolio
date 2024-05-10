using System.Net;
using System.Net.Mail;

namespace Judah_Kahler_Portfolio
{
    public class EmailSender :  IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "judah.kahler@gmail.com";
            var pw = "fgwu aneo isza vapw";

            string completeMessage = message + " \r\n\r\n" + "Email: " + email;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: mail,
                subject,
                completeMessage));
        }
    }
}