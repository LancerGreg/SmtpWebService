using SmtpWebService.Core;
using SmtpWebService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmtpWebService.Domain.Services
{
    public interface IMailService
    {
        Task<ITry<string>> SmtpSendEmailAsync(MessageSetting message, MailSetting mail);
    }
}
