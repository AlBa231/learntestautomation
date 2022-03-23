using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public abstract class VehicleException:Exception
{
    protected VehicleException()
    {
    }

    protected VehicleException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    protected VehicleException(string? message) : base(message)
    {
    }

    protected VehicleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}