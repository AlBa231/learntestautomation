using System.Xml.Serialization;
using VehiclePrinter.Models;

namespace VehiclePrinter
{
    [Serializable]
    public class VehicleByTransmissionList
    {
        public XmlSerializableDictionary<TransmissionType, VehicleList> Vehicles { get; set; } = new();

        private IList<Vehicle> initialVehicles;

        public VehicleByTransmissionList() { }

        public VehicleByTransmissionList(IList<Vehicle> vehicles)
        {
            initialVehicles = vehicles;
            var transmissions = vehicles.Select(v => v.Transmission.Type).Distinct();
            foreach (var transmission in transmissions)
            {
                Vehicles.Add(transmission, FilterVehiclesByTransmission(transmission));
            }
        }

        private VehicleList FilterVehiclesByTransmission(TransmissionType transmissionType)
        {
            return new VehicleList(initialVehicles.Where(v => v.Transmission.Type == transmissionType));
        }

        public void Save(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Create);
            Save(fs);
        }
        public void Save(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(VehicleByTransmissionList));

            serializer.Serialize(fileStream, this);
        }
    }
}
