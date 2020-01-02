using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SmtpWebService.Domain.Models
{
    public class MessageSetting
    {
        [DataMember(Name = "text")] public string Text { get; set; }
        [DataMember(Name = "htmlBody")]  public string Body { get; set; }
    }
}
