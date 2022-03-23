
using System.Runtime.CompilerServices;
using VehiclePrinter;
using VehiclePrinter.Models;

var vehicles = RandomVehicleFactory.CreateRandomVehicles(10);

Console.WriteLine("Vehicles with specifications:!");

for (var i = 0; i < vehicles.Count; i++)
{
    Console.WriteLine(GetVehicleHeader(vehicles[i], i));
    Console.WriteLine(vehicles[i]);
    Console.WriteLine(new string('=', 80));
    Console.WriteLine();
}

var largeEngineVehicles = new VehicleList(vehicles.Where(vehicle => vehicle.Engine.Capacity > 1500));
largeEngineVehicles.Save("large.xml");


var vehicleByTransmission = new VehicleByTransmissionList(vehicles);
vehicleByTransmission.Save("transmission.xml");

string GetVehicleHeader(Vehicle vehicle, int index) => $"{index + 1}. {vehicle.GetType().Name}";
