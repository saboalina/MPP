using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator3.domain.validators
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String message) : base(message) { }
    }
}
