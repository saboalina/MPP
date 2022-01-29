using System;

namespace AgentieDeTurism.service
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(String message): base(message) { }
    }
}