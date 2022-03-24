using System.Collections.Generic;
using CarCalculator.Lib;

namespace CarCalculator.Test
{
    internal static class Stubs
    {
        internal static IEnumerable<Car> InitCars()
        {
            return new[]
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
            };
        }
    }
}
