using System.Xml.Serialization;
using VehiclePrinter.Models;

namespace VehiclePrinter
{
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public class VehicleList: List<Vehicle>
    {
        public VehicleList()
        {
        }

        public VehicleList(IEnumerable<Vehicle> collection) : base(collection)
        {
        }

        public void Save(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(VehicleList));

            serializer.Serialize(fileStream, this);
        }
    }
}
