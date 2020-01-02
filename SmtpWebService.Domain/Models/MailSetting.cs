using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SmtpWebService.Domain.Models
{
    public class MailSetting
    {
        [DataMember(Name = "addressFrom")] public string MailAddressFrom { get; set; }
        [DataMember(Name = "password")] public string Password { get; set; }
        [DataMember(Name = "name")] public string Name { get; set; }
        [DataMember(Name = "addressTo")] public string MailAddressTo { get; set; }
    }
}
