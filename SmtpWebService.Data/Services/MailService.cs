using SmtpWebService.Core;
using SmtpWebService.Core.ExceptionError;
using SmtpWebService.Domain.Models;
using SmtpWebService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpWebService.Data.Services
{
    public class MailService : IMailService
    {
        public async Task<ITry<string>> SmtpSendEmailAsync(MessageSetting message, MailSetting mail)
        {
            if (mail.MailAddressFrom == null)
                return await Task.FromResult(new Failure<string>(new NullAddressFromFailure()));
            if (mail.MailAddressTo == null)
                return await Task.FromResult(new Failure<string>(new NullAddressToFailure()));
            if (mail.Password == null)
                return await Task.FromResult(new Failure<string>(new NullPasswordFailure()));

            MailAddress from = new MailAddress(mail.MailAddressFrom, mail.Name);
            MailAddress to = new MailAddress(mail.MailAddressTo);

            using (MailMessage mailMessage = new MailMessage(from, to))
            using (SmtpClient smtp = new SmtpClient())
            {
                mailMessage.Subject = message.Text;
                mailMessage.Body = message.Body;
                mailMessage.IsBodyHtml = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from.Address, mail.Password);

                return await smtp.AsOption().MatchAsync<ITry<string>>(
                    async ms => {
                        try
                        {
                            await ms.SendMailAsync(mailMessage);
                        } 
                        catch(Exception e)
                        {
                            return await Task.FromResult(new Failure<string>(new UserAuthenticationError()));
                        }
                        
                        return await Task.FromResult(new Success<string>("MailSend"));
                    },
                    async () => await Task.FromResult(new Failure<string>(new SendMessageFailure())));
            }
        }
    }
}
