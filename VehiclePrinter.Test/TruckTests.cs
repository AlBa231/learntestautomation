using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test;

public class TruckTests
{
    [Fact]
    public void TestTruckToString()
    {
        var engine = new VehicleEngine
        {
            Power = 420,
            Capacity = 12740,
            Type = EngineType.Diesel,
            SerialNumber = "1AASDTZ-F34FwaE"
        };

        var chassis = new VehicleChassis
        {
            WheelCount = 9,
            Number = "83250D0102526",
            MaxLoad = 15205
        };

        var transmission = new Transmission
        {
            Type = TransmissionType.Manual,
            GearsNumber = 16,
            Manufacturer = "Smart Electronic"
        };

        var truck = new Truck
        {
            Engine = engine,
            Chassis = chassis,
            Transmission = transmission,
            Model = "Cargo",
            Make = "Ford",
            Height = 3245,
            Width = 2540
        };
        
        Assert.Equal(@"Ford Cargo 12.7 (420 hp), Diesel (1AASDTZ-F34FwaE).
9 wheels, 15205 kg, 83250D0102526,
Manual, 16 gears, Smart Electronic
Dimensions (HxW): 3245x2540", truck.ToString());
    }
}