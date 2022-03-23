using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public class VehicleInitializationException : VehicleException
{
    public VehicleInitializationException()
    {
    }

    public VehicleInitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VehicleInitializationException(string? message) : base(message)
    {
    }

    public VehicleInitializationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}