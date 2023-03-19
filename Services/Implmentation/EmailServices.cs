using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implmentation
{
    public class EmailService : IEmailService
    {
        private readonly string _fromAddress;
        private readonly string _fromPassword;
        //private readonly SmtpClient _smtpClient;
        //smtp-mail.outlook.com   //587  //STARTTLS

        public EmailService(string fromAddress, string fromPassword)
        {
            _fromAddress = fromAddress;
            _fromPassword = fromPassword;
        }

        public void SendEmail(string toAddress, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_fromAddress),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(toAddress));
            var buldier = new BodyBuilder();
            buldier.HtmlBody = body;
            email.Body = buldier.ToMessageBody();
            email.From.Add(new MailboxAddress("ejada task", _fromAddress));
            using var smtp = new SmtpClient();
            smtp.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_fromAddress, _fromPassword);
            smtp.Send(email);

            smtp.Disconnect(true);
        }
    }
}