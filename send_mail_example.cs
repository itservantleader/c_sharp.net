using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Security;
using System.Xml.Linq;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var email = new MimeMessage();
            Console.Write("Send Email To: ");
            string? email_to = Console.ReadLine();

            Console.Write("Subject: ");
            email.Subject = Console.ReadLine();

            Console.Write("Message: ");
            string? email_body = Console.ReadLine();

			// Change the values below for the From email address
            email.From.Add(new MailboxAddress("From Name", "from@DomainName.com")); 
            email.To.Add(new MailboxAddress("", email_to));
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = email_body
            };
            using (var smtp = new SmtpClient())
            {
             	// Change the SMTP server name below
                smtp.Connect("smtp.DomainName.com", 587, SecureSocketOptions.StartTls);

                // Note: only needed if the SMTP server requires authentication
                // If authentication is required, update the user name and password below.
                smtp.Authenticate("SMTP_User_Name", "SMTP_User_Password");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
