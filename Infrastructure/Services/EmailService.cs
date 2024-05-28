using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailServices
    {
        private readonly string senderEmail;
        private readonly string senderPassword;
        private readonly string smtpServer;
        private readonly int smtpPort;

        public EmailServices(IConfiguration config)
        {
            senderEmail = "fadelkhalaf5566@gmail.com";
            senderPassword = "epkbfwjsklhxuhom";
            smtpServer = "smtp.gmail.com";
            smtpPort = 587;
        }
        public async Task<string> SendMail(string email, string subject, string body)
        {

            try
            {
                string recipientEmail = email;

                MailMessage mail = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                SmtpClient smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Send(mail);
                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return ex.Message;
            }
        }
        public async Task<string> SendMail(MailMessage mailMessage)
        {
            using var smtpClient = new SmtpClient(smtpServer)
            {
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(mailMessage);
            return "Email sent successfully!";
        }


        public async Task SendVerificationEmailAsync(string toEmail, string userName, string verificationLink)
        {
            string htmlTemplate = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Email Verification</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f4f4f4;\r\n            margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        .container {\r\n            width: 100%;\r\n            padding: 20px;\r\n            background-color: #ffffff;\r\n            border: 1px solid #dddddd;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n            max-width: 600px;\r\n            margin: 40px auto;\r\n        }\r\n\r\n        .header {\r\n            text-align: center;\r\n            padding-bottom: 20px;\r\n            border-bottom: 1px solid #dddddd;\r\n        }\r\n\r\n            .header img {\r\n                max-width: 100px;\r\n            }\r\n\r\n        .content {\r\n            padding: 20px;\r\n        }\r\n\r\n            .content h1 {\r\n                font-size: 24px;\r\n                color: #333333;\r\n            }\r\n\r\n            .content p {\r\n                font-size: 16px;\r\n                color: #666666;\r\n            }\r\n\r\n            .content a {\r\n                display: inline-block;\r\n                padding: 10px 20px;\r\n                color: #ffffff;\r\n                background-color: #28a745;\r\n                text-decoration: none;\r\n                border-radius: 5px;\r\n                margin-top: 20px;\r\n            }\r\n\r\n        .footer {\r\n            text-align: center;\r\n            padding: 20px;\r\n            font-size: 14px;\r\n            color: #999999;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n       </div>\r\n        <div class=\"content\">\r\n            <h1>Email Verification</h1>\r\n            <p>Hi {{UserName}},</p>\r\n            <p>Thank you for registering with us. Please click the button below to verify your email address:</p>\r\n            <a href=\"{{VerificationLink}}\">Verify Email</a>\r\n            <p>If you did not create an account, no further action is required.</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2024 Course Management. All rights reserved.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n";
            htmlTemplate = htmlTemplate.Replace("{{UserName}}", userName);
            htmlTemplate = htmlTemplate.Replace("{{VerificationLink}}", verificationLink);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, "Course Management"),
                Subject = "Email Verification",
                Body = htmlTemplate,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);
            await SendMail(mailMessage);

        }
    }
}
