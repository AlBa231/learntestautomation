
using VehiclePrinter;
using VehiclePrinter.Models;

var vehicles = new List<Vehicle>(new int[10].Select(_ => RandomVehicleFactory.CreateRandomVehicle()));

Console.WriteLine("Vehicles with specifications:!");

for (var i = 0; i < vehicles.Count; i++)
{
    Console.WriteLine(GetVehicleHeader(vehicles[i], i));
    Console.WriteLine(vehicles[i]);
    Console.WriteLine(new string('=', 80));
    Console.WriteLine();
}



string GetVehicleHeader(Vehicle vehicle, int index) => $"{index + 1}. {vehicle.GetType().Name}";
