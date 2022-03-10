using VehiclePrinter.Models;

namespace VehiclePrinter
{
    public static class VehicleFactory
    {
        public static Vehicle CreateCar()
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
                Number = "231000В0102526",
                MaxLoad = 570
            };

            var transmission = new Transmission
            {
                Type = TransmissionType.Automatic,
                GearsNumber = 5,
                Manufacturer = "Aisin Japan"
            };

            return new Car
            {
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission,
                Model = "Camry",
                Make = "Toyota"
            };
        }
    }
}
