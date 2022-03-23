using VehiclePrinter.Exceptions;
using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleExceptionTests
    {
        [Fact]
        public void TestInitializationException()
        {
            var chassis = new VehicleChassis
            {
                MaxLoad = 500,
                Number = "ASDKJ125432ASD",
                WheelCount = 3
            };

            Assert.Throws<VehicleInitializationException>(() => new Car { Chassis = chassis });
        }
    }
}
