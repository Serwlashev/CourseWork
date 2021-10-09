using System;

namespace Services.ServicesShared.Core.Exceptions
{
    public class ForbiddenActionException : ApplicationException
    {
        public ForbiddenActionException(string message)
            : base(message)
        {
        }
    }
}
