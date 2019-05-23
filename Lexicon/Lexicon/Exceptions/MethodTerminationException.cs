namespace Lexicon.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    public class MethodTerminationException : Exception
    {
        public MethodTerminationException()
        {
        }

        public MethodTerminationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MethodTerminationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
