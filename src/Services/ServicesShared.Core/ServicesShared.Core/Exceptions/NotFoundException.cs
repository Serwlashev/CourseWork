using System;

namespace Services.ServicesShared.Core.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
