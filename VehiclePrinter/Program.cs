using VehiclePrinter;

var vehicles = RandomVehicleFactory.CreateRandomVehicles(10);

Console.WriteLine("Vehicles with specifications:!");

var printer = new VehiclePrinter.VehiclePrinter(vehicles);

printer.ShowVehicleInfo();

printer.SaveLargeEngineVehicles("large.xml");
printer.SaveBusAndTruckEngines("engines.xml");
printer.SaveVehiclesByTransmission("transmission.xml");
