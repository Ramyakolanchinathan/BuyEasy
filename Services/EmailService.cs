using System.Net.Mail;
using System.Net;

namespace BuyEasy.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("ramsnath2002@gmail.com", "BuyEasy");
            var toAddress = new MailAddress(to);
            const string fromPassword = "jckp eoez muxf qddi"; // Not Gmail password — use App Password

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true // use true if HTML content
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}

