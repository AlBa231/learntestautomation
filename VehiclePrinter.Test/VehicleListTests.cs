using System.IO;
using System.Xml.Serialization;
using Xunit;

namespace VehiclePrinter.Test
{
    public class VehicleListTests
    {
        [Fact]
        public void TestCreateFullInfoXml()
        {
            var vehicles = RandomVehicleFactory.CreateRandomVehicles(4);
            var stream = new MemoryStream();

            vehicles.Save(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var vehicles2 = (VehicleList)new XmlSerializer(typeof(VehicleList)).Deserialize(stream)!;

            Assert.NotNull(vehicles2);
            Assert.Equal(vehicles.Count, vehicles2.Count);
            Assert.Equal(vehicles[0].Make, vehicles2[0].Make);
        }
    }
}
