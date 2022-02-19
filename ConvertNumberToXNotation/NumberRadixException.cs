using System.Runtime.Serialization;

namespace ConvertNumberToXNotation
{
    [Serializable]
    public class NumberRadixException : Exception
    {
        public NumberRadixException()
        {
        }

        public NumberRadixException(string? message) : base(message)
        {
        }

        public NumberRadixException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NumberRadixException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}