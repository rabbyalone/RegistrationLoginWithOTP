using LoginWithOTP.ViewModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LoginWithOTP.Repository
{
    public class EmailSender: IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailSetup mailSetup = new MailSetup 
                {
                    Server = "smtp.gmail.com",
                    Port = 587,
                    EnableSSL = true,
                    FromMail = "EXAMPLE@gmail.com",
                    FromMailPassword = "PASSWORD"
                };
               
               
                    MailMessage message = new MailMessage();
                    message.Subject = subject;
                    message.Body = htmlMessage;
                    message.IsBodyHtml = true;
                    message.To.Add(email);

                    message.From = new MailAddress(mailSetup.FromMail);

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = mailSetup.Server;
                    smtpClient.Port = mailSetup.Port;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(mailSetup.FromMail, mailSetup.FromMailPassword);
                    smtpClient.EnableSsl = mailSetup.EnableSSL;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    await smtpClient.SendMailAsync(message);
                }
            }
            catch (SmtpException smtp)
            {
                //throw new SmtpException(smtp.Message);
            }
            catch (Exception ex)
            {
               // throw new ArgumentException(ex.Message);
            }
        }
    }
}
