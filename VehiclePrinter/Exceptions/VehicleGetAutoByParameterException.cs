using System.Runtime.Serialization;

namespace VehiclePrinter.Exceptions;

[Serializable]
public class VehicleGetAutoByParameterException : VehicleException
{
    public VehicleGetAutoByParameterException()
    {
    }

    public VehicleGetAutoByParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public VehicleGetAutoByParameterException(string? message) : base(message)
    {
    }

    public VehicleGetAutoByParameterException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}