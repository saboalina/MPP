using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain.validators
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String message) : base(message) { }
    }
}
