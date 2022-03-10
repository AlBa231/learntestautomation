using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleChassisTests
    {
        [Fact]
        public void TestChassisToString()
        {
            var chassis = new VehicleChassis
            {
                WheelCount = 4,
                Number = "231000В0102526",
                MaxLoad = 570
            };

            Assert.Equal("4 wheels, 570 kg, 231000В0102526", chassis.ToString());
        }
    }
}
