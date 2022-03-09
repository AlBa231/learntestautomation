using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleEngineTests
    {

        [Fact]
        public void TestEngineRoundCapacity_MustRoundToBigger()
        {
            var engine = new VehicleEngine
            {
                Power = 170,
                Capacity = 2362,
                Type = EngineType.Gasoline,
                SerialNumber = "2AZ-FE"
            };

            Assert.Equal(2.4, engine.RoundedCapacity);
        }

        [Fact]
        public void TestEngineRoundCapacity_MustRoundToSmaller()
        {
            var engine = new VehicleEngine
            {
                Power = 170,
                Capacity = 1112,
                Type = EngineType.Gasoline,
                SerialNumber = "2AZ-FE"
            };

            Assert.Equal(1.1, engine.RoundedCapacity);
        }
    }
}
