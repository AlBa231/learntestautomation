using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public class VehicleAddException : VehicleException
{
    public VehicleAddException()
    {
    }

    public VehicleAddException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VehicleAddException(string? message) : base(message)
    {
    }

    public VehicleAddException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}