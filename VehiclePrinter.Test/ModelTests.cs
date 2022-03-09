using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class ModelTests
    {
        [Fact]
        public void TestCar()
        {
            var engine = new VehicleEngine
            {
                Power = 170,
                Capacity = 2362,
                Type = EngineType.Gasoline,
                SerialNumber = "2AZ-FE"
            };

            var chassis = new VehicleChassis
            {
                WheelCount = 4,
                Number = "231000Â0102526",
                MaxLoad = 570
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Automatic,
                GearsNumber = 5,
                Manufacturer = "Aisin Japan"
            };

            var car = new Car
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "Camry",
                Make = "Toyota"
            };


            Assert.Equal(@"Toyota Camry 2.4 (170 hp), Gasoline.
4 wheels, 570 kg, 231000Â0102526,
Automatic, 5 gears, Aisin Japan", car.ToString());
        }
    }

}