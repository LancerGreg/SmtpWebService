using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpWebService.Core.ExceptionError
{
    public class SendMessageFailure : ExceptionTermFailure
    {
        public SendMessageFailure() : base(ExceptionTerm.SendMessageFailure)
        {
        }
    }
    public class NullAddressFromFailure : ExceptionTermFailure
    {
        public NullAddressFromFailure() : base(ExceptionTerm.NullAddressFromFailure)
        {
        }
    }
    public class NullAddressToFailure : ExceptionTermFailure
    {
        public NullAddressToFailure() : base(ExceptionTerm.NullAddressToFailure)
        {
        }
    }
    public class NullPasswordFailure : ExceptionTermFailure
    {
        public NullPasswordFailure() : base(ExceptionTerm.NullPasswordFailure)
        {
        }
    }
    public class UserAuthenticationError : ExceptionTermFailure
    {
        public UserAuthenticationError() : base(ExceptionTerm.UserAuthenticationError)
        {
        }
    }    
}
