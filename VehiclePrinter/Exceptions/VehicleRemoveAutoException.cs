using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public class VehicleRemoveAutoException : VehicleException
{
    public VehicleRemoveAutoException()
    {
    }

    public VehicleRemoveAutoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VehicleRemoveAutoException(string? message) : base(message)
    {
    }

    public VehicleRemoveAutoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}