using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpWebService.Core.ExceptionError
{
    public enum ExceptionTerm
    {
        SendMessageFailure,
        NullAddressFromFailure,
        NullAddressToFailure,
        NullPasswordFailure,
        UserAuthenticationError
    }
}
