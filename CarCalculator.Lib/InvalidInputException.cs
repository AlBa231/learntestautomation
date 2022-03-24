using System.Runtime.Serialization;

namespace CarCalculator
{
    [Serializable]
    public class InvalidInputException: Exception
    {
        public InvalidInputException():this("Input cannot be NULL.")
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidInputException(string? message) : base(message)
        {
        }

        public InvalidInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
