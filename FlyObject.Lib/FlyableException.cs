// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization;

namespace FlyObject
{
    [Serializable]
    public class FlyableException : Exception
    {
        public FlyableException()
        {
        }

        public FlyableException(string? message) : base(message)
        {
        }

        public FlyableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FlyableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}