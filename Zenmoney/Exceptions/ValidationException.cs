using System;
using System.Collections.Generic;
using System.Text;
using Zenmoney.Errors;

namespace Zenmoney.Exceptions
{
    class ValidationException : Exception
    {
        public ValidationError Error { get; }

        public ValidationException(ValidationError error) : base(error.Message)
        {
            Error = error;
        }
    }
}
