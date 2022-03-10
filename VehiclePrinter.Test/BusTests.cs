using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test;

public class BusTests
{
    [Fact]
    public void TestBusToString()
    {
        var engine = new VehicleEngine
        {
            Power = 320,
            Capacity = 10760,
            Type = EngineType.Diesel,
            SerialNumber = "2ABSSTZ-F34AAS11"
        };

        var chassis = new VehicleChassis
        {
            WheelCount = 12,
            Number = "2315321D02321E",
            MaxLoad = 14384
        };

        var transmission = new Transmission
        {
            Type = TransmissionType.Manual,
            GearsNumber = 6,
            Manufacturer = "Alarus Megatronics"
        };

        var bus = new Bus
        {
            Engine = engine,
            Chassis = chassis,
            Transmission = transmission,
            Model = "695",
            Make = "Ikarus",
            PassengerSeatCount = 50,
            HandicappedSeatCount = 2,
            HasToilet = true
        };


        Assert.Equal(@"Ikarus 695 10.8 (320 hp), Diesel (2ABSSTZ-F34AAS11).
12 wheels, 14384 kg, 2315321D02321E,
Manual, 6 gears, Alarus Megatronics
Seats: 50 + 2, Toilet", bus.ToString());
    }
}