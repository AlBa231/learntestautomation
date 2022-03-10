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

        [Fact]
        public void TestVehicleFactory_CreateBus()
        {
            var bus = VehicleFactory.CreateBus();
            
            Assert.Equal(@"Ikarus 695 10.8 (320 hp), Diesel (2ABSSTZ-F34AAS11).
12 wheels, 14384 kg, 2315321D02321E,
Manual, 6 gears, Alarus Megatronics
Seats: 50 + 2, Toilet", bus.ToString());
        }

        [Fact]
        public void TestVehicleFactory_CreateScooter()
        {
            var scooter = VehicleFactory.CreateScooter();

            Assert.Equal(@"MUSSTANG Alfa 0.1 (8 hp), Gasoline (2ABS22Z-F3123AS11).
2 wheels, 180 kg, 1235324402321E,
Manual, 2 gears, CHOHO 428
Seats: 1, Alarm", scooter.ToString());
        }
    }
}
