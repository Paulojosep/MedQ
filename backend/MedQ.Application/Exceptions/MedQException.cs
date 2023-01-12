using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.Exceptions
{
    public class MedQException : ApplicationException
    {
        public MedQException()
        {}

        public MedQException(string message) : base(message)
        {}

        public MedQException(string message, Exception inner) : base(message)
        {}
    }
}
