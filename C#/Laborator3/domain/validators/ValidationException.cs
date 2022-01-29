using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.domain.validators
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String message) : base(message) { }
    }
}
