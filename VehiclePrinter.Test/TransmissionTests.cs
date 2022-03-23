using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class TransmissionTests
    {


        [Fact]
        public void TestTransmissionToString()
        {
            var transmission = new Transmission
            {
                Type = TransmissionType.Automatic,
                GearsNumber = 5,
                Manufacturer = "Aisin Japan"
            };

            Assert.Equal("Automatic, 5 gears, Aisin Japan", transmission.ToString());
        }
    }
}
