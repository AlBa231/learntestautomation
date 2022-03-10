using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test;

public class ScooterTests
{
    [Fact]
    public void TestScooterToString()
    {
        var engine = new VehicleEngine
        {
            Power = 8,
            Capacity = 125,
            Type = EngineType.Gasoline,
            SerialNumber = "2ABS22Z-F3123AS11"
        };

        var chassis = new VehicleChassis
        {
            WheelCount = 2,
            Number = "1235324402321E",
            MaxLoad = 180
        };

        var transmission = new Transmission
        {
            Type = TransmissionType.Manual,
            GearsNumber = 2,
            Manufacturer = "CHOHO 428"
        };

        var scooter = new Scooter
        {
            Engine = engine,
            Chassis = chassis,
            Transmission = transmission,
            Model = "Alfa",
            Make = "MUSSTANG",
            HasAlarm = true,
            SeatCount = 1
        };
        
        Assert.Equal(@"MUSSTANG Alfa 0.1 (8 hp), Gasoline (2ABS22Z-F3123AS11).
2 wheels, 180 kg, 1235324402321E,
Manual, 2 gears, CHOHO 428
Seats: 1, Alarm", scooter.ToString());
    }
}