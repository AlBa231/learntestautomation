using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public class VehicleUpdateAutoException : VehicleException
{
    public VehicleUpdateAutoException()
    {
    }

    public VehicleUpdateAutoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VehicleUpdateAutoException(string? message) : base(message)
    {
    }

    public VehicleUpdateAutoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}