using VehiclePrinter.Exceptions;
using Xunit;

namespace VehiclePrinter.Test
{
    public class FindVehicleByParameterTests
    {
        [Fact]
        public void TestFindVehicleByEngineNumber()
        {
            var vehicles = RandomVehicleFactory.CreateRandomVehicles(10);
            var testVehicle = vehicles[5];
            var engineNumber = testVehicle.Engine.SerialNumber;

            var foundVehicle = vehicles.GetAutoByParameter("EngineNumber", engineNumber);

            Assert.Equal(testVehicle, foundVehicle);
        }

        [Fact]
        public void TestFindVehicleByEngineNumberException()
        {
            var vehicles = RandomVehicleFactory.CreateRandomVehicles(10);
            var testVehicle = vehicles[5];
            var engineNumber = testVehicle.Engine.SerialNumber;

            Assert.Throws<VehicleGetAutoByParameterException>(() => vehicles.GetAutoByParameter("EngineNumbera", engineNumber));
        }
    }
}
