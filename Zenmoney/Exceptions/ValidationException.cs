using System;
using System.Collections.Generic;
using System.Text;
using Zenmoney.Errors;

namespace Zenmoney.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationError Error { get; }

        public ValidationException(ValidationError error) : base(error?.Message)
        {
            Error = error;
        }

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
