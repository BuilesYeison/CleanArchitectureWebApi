using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class FooBarException : Exception
    {
        public FooBarException()
        {
        }

        public FooBarException(string? message) : base(message)
        {
        }

        public FooBarException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FooBarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
