using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleGeneratorTests
    {
        [Fact]
        public void TestVehicleFactory_CreateCar()
        {
            var car = VehicleFactory.CreateCar();
            
            Assert.Equal(@"Toyota Camry 2.4 (170 hp), Gasoline (2AZ-FE).
4 wheels, 570 kg, 231000В0102526,
Automatic, 5 gears, Aisin Japan", car.ToString());
        }

        [Fact]
        public void TestVehicleFactory_CreateTruck()
        {
            var truck = VehicleFactory.CreateTruck();

            Assert.Equal(@"Ford Cargo 12.7 (420 hp), Diesel (1AASDTZ-F34FwaE).
9 wheels, 15205 kg, 83250D0102526,
Manual, 16 gears, Smart Electronic
Dimensions (HxW): 3245x2540", truck.ToString());
        }
    }
}
