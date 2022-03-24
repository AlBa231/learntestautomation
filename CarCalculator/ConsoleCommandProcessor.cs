using System.Globalization;
using CarCalculator.Lib;

namespace CarCalculator
{
    internal class ConsoleCommandProcessor
    {
        private const int TotalCarRequests = 5;
        public void RequestCars()
        {
            //RequestCarInfos();
            CarCommander.Instance.AddCar(new[]
            {
                new Car { VehiclePrice = 1000, VehicleCount = 1, Make = "Nissan", Model = "Versa" },
                new Car { VehiclePrice = 2000, VehicleCount = 5, Make = "Nissan", Model = "Sentra" },
                new Car { VehiclePrice = 3000, VehicleCount = 4, Make = "Nissan", Model = "Altima" },
                new Car { VehiclePrice = 4000, VehicleCount = 5, Make = "Toyota", Model = "Avalon" },
                new Car { VehiclePrice = 5000, VehicleCount = 2, Make = "Toyota", Model = "Belta" },
                new Car { VehiclePrice = 21000, VehicleCount = 5, Make = "Toyota", Model = "Camry" },
                new Car { VehiclePrice = 21500, VehicleCount = 6, Make = "VAZ", Model = "2106" },
                new Car { VehiclePrice = 27000, VehicleCount = 7, Make = "VAZ", Model = "2107" },
                new Car { VehiclePrice = 21000, VehicleCount = 5, Make = "VAZ", Model = "2110" },
                new Car { VehiclePrice = 20000, VehicleCount = 11, Make = "Audi", Model = "e-tron" },
                new Car { VehiclePrice = 21000, VehicleCount = 5, Make = "Audi", Model = "A4" },
                new Car { VehiclePrice = 8000, VehicleCount = 8, Make = "Audi", Model = "A5" },
                new Car { VehiclePrice = 9000, VehicleCount = 5, Make = "Volvo", Model = "A6" },
                new Car { VehiclePrice = 6000, VehicleCount = 15, Make = "Volvo", Model = "A7" },
                new Car { VehiclePrice = 7000, VehicleCount = 1, Make = "Audi", Model = "A8" },
                new Car { VehiclePrice = 11000, VehicleCount = 5, Make = "Audi", Model = "Q3" },
                new Car { VehiclePrice = 18000, VehicleCount = 23, Make = "Ford", Model = "Focus" },
                new Car { VehiclePrice = 29000, VehicleCount = 4, Make = "Ford", Model = "Cargo" }
            });
            while (true)
            {
                ProcessCommands();
            }
        }

        private void RequestCarInfos()
        {
            for (var i = 0; i < TotalCarRequests; i++)
            {
                TryRequestCarInfo();
            }
        }

        private void ProcessCommands()
        {
            PrintCommands();
            var command = CommandFactory.FindCommand(Console.ReadLine() ?? throw new InvalidInputException());
            CarCommander.Instance.ExecuteCommand(command);
        }
        
        private static void PrintCommands()
        {
            Console.WriteLine("Please, select a command:");
            Console.WriteLine($"{CommandFactory.CommandCountTypes} - count makes");
            Console.WriteLine($"{CommandFactory.CommandCountAll} - count all cars");
            Console.WriteLine($"{CommandFactory.CommandAveragePrice} [make] - count average car price [for make]");
            Console.WriteLine($"{CommandFactory.CommandQuit} - quit");
        }

        private void TryRequestCarInfo()
        {
            try
            {
                CarCommander.Instance.AddCar(RequestCarInfo());
            }
            catch(InvalidInputException e)
            {
                Console.WriteLine("Error: " + e.Message);
                TryRequestCarInfo();
            }
        }

        private Car RequestCarInfo()
        {
            var car = new Car();

            Console.WriteLine("Please, enter car info.");
            Console.WriteLine("Make:");
            car.Make = Console.ReadLine() ?? throw new InvalidInputException();

            Console.WriteLine("Model:");
            car.Model = Console.ReadLine() ?? throw new InvalidInputException();

            Console.WriteLine("Total amount of cars:");
            car.VehicleCount = ReadNumber();

            Console.WriteLine("Car price:");
            car.VehiclePrice = ReadNumber();

            return car;
        }

        private static int ReadNumber()
        {
            try
            {
                return int.Parse(Console.ReadLine() ?? throw new InvalidInputException(), CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw new InvalidInputException(e.Message, e);
            }
        }
    }
}
