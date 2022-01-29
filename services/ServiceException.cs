using System;

namespace services
{
    public class ServiceException : ApplicationException
    {
        public ServiceException(String message): base(message) { }
    }
}