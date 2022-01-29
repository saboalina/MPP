using System;

namespace model.validators
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String message): base(message) { }
    }
}