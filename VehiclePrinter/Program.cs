
using VehiclePrinter;
using VehiclePrinter.Models;

var cars = new []
{
    VehicleFactory.CreateCar(),
    VehicleFactory.CreateTruck(),
};

Console.WriteLine("Vehicles with specifications:!");

for (var i = 0; i < cars.Length; i++)
{
    Console.WriteLine(GetVehicleHeader(cars[i], i));
    Console.WriteLine(cars[i]);
    Console.WriteLine(new string('=', 80));
    Console.WriteLine();
}

string GetVehicleHeader(Vehicle vehicle, int index) => $"{index + 1}. {vehicle.GetType().Name}";
