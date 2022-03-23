using System.IO;
using System.Linq;
using System.Xml;
using VehiclePrinter.Models;
using Xunit;

namespace VehiclePrinter.Test
{
    public class SimpleXmlWriterTests
    {
        [Fact]
        public void TestCreateXmlDocument()
        {
            using var stream = new MemoryStream();
            var car = RandomVehicleFactory.CreateCar();
            var writer = new SimpleXmlWriter(car);

            writer.Save(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var doc = new XmlDocument();
            doc.Load(stream);

            Assert.NotNull(doc.DocumentElement);
            Assert.NotNull(doc.DocumentElement[nameof(Car.Make)]);
            Assert.Equal(car.Make, doc.DocumentElement[nameof(Car.Make)].InnerText);
        }
        
        [Fact]
        public void TestCreateXmlDocumentWithList()
        {
            using var stream = new MemoryStream();
            var vehicles = RandomVehicleFactory.CreateRandomVehicles(5);
            var writer = new SimpleXmlWriter(vehicles);

            writer.Save(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var doc = new XmlDocument();
            doc.Load(stream);

            Assert.NotNull(doc.DocumentElement);
            Assert.Equal(5, doc.DocumentElement.ChildNodes.Count);
        }

        [Fact]
        public void TestCreateXmlDocumentDictionary()
        {
            using var stream = new MemoryStream();
            var vehicles = RandomVehicleFactory.CreateRandomVehicles(5).GroupBy(g=>g.Transmission.Type)
                .ToDictionary(g=>g.Key, g=>new VehicleList(g));
            var writer = new SimpleXmlWriter(vehicles);

            writer.Save(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var doc = new XmlDocument();
            doc.Load(stream);

            Assert.NotNull(doc.DocumentElement);
            Assert.Equal(2, doc.DocumentElement.ChildNodes.Count);
        }
    }
}
