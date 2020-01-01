using System;
using System.Collections.Generic;
using System.Text;

namespace SmtpWebService.Core.ExceptionError
{
    public abstract class ExceptionTermFailure : Exception
    {
        private ExceptionTerm ExceptionTerm { get; }
        protected ExceptionTermFailure(ExceptionTerm exceptionTerm)
        {
            ExceptionTerm = exceptionTerm;
        }
    }
}
