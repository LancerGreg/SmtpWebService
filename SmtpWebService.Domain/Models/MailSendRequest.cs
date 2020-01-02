using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpWebService.Domain.Models
{
    public class MailSendRequest
    {
        public string To { get; }
        public string Subject { get; }
        public string Body { get; }
    }
}
