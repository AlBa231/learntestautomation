using VehiclePrinter.Exceptions;

namespace VehiclePrinter.Models;

public class Car : Vehicle
{
    protected override void Validate()
    {
        base.Validate();
        if (Chassis is { WheelCount: < 4 })
            throw new VehicleInitializationException("Car cannot have less than 4 wheels.");
    }
}
