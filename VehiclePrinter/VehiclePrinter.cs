using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePrinter.Models;

namespace VehiclePrinter
{
    public class VehiclePrinter
    {
        public VehicleList Vehicles { get; }

        public VehiclePrinter(IEnumerable<Vehicle> vehicles)
        {
            if (vehicles == null) throw new ArgumentNullException(nameof(vehicles));
            Vehicles = new VehicleList(vehicles);
        }
        public void ShowVehicleInfo()
        {
            for (var i = 0; i < Vehicles.Count; i++)
            {
                PrintVehicleInfo(Vehicles[i], i);
            }
        }

        public void SaveLargeEngineVehicles(string fileName)
        {
            var largeEngineVehicles = Vehicles.Where(vehicle => vehicle.Engine.Capacity > 1500);
            new VehicleList(largeEngineVehicles).Save(fileName);
        }
        public void SaveVehiclesByTransmission(string fileName)
        {
            var vehiclesByGroup = Vehicles.GroupBy(g => g.Transmission.Type)
                            .ToDictionary(g => g.Key, g => new VehicleList(g));
            var vehicleByTransmissionXml = new SimpleXmlWriter(vehiclesByGroup);
            vehicleByTransmissionXml.Save("transmission.xml");

        }

        private static void PrintVehicleInfo(Vehicle vehicle, int index)
        {
            Console.WriteLine($"{index + 1}. {vehicle.GetType().Name}");
            Console.WriteLine(vehicle);
            Console.WriteLine(new string('=', 80));
            Console.WriteLine();
        }

    }
}
