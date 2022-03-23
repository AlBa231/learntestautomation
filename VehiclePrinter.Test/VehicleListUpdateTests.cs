using VehiclePrinter.Exceptions;
using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleListUpdateTests
    {
        [Fact]
        public void TestUpdateAutoOk()
        {
            var vehicleList = RandomVehicleFactory.CreateRandomVehicles(10);
            var car = RandomVehicleFactory.CreateCar();

            vehicleList.ReplaceCarById(vehicleList[5].Id, car);

            Assert.Equal(car, vehicleList[5]);
        }

        [Fact]
        public void TestUpdateAutoException()
        {
            var vehicleList = new VehicleList();
            var car = RandomVehicleFactory.CreateCar();

            Assert.Throws<VehicleUpdateAutoException>(() => vehicleList.ReplaceCarById("bad", car));
        }
    }
}
