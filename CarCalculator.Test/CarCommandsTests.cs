using CarCalculator.Lib;
using Xunit;

namespace CarCalculator.Test
{
    public class CarCommandsTests
    {
        public CarCommandsTests()
        {
            CarCommander.Instance.AddCar(new Car());
        }

        [Fact]
        public void TestCountTypesCars()
        {
            var cars = InitCars();
            var command = new CountTypesCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total number of makes: 5 (Nissan, Toyota, VAZ, Audi, Ford)", result);
        }

        [Fact]
        public void TestCountCars()
        {
            var cars = InitCars();
            var command = new CountCarsCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total amount of cars: 117", result);
        }

        private static Car[] InitCars()
        {
            return new[]
            {
                new Car { VehicleCount = 1, Make = "Nissan", Model = "Versa" },
                new Car { VehicleCount = 5, Make = "Nissan", Model = "Sentra" },
                new Car { VehicleCount = 4, Make = "Nissan", Model = "Altima" },
                new Car { VehicleCount = 5, Make = "Toyota", Model = "Avalon" },
                new Car { VehicleCount = 2, Make = "Toyota", Model = "Belta" },
                new Car { VehicleCount = 5, Make = "Toyota", Model = "Camry" },
                new Car { VehicleCount = 6, Make = "VAZ", Model = "2106" },
                new Car { VehicleCount = 7, Make = "VAZ", Model = "2107" },
                new Car { VehicleCount = 5, Make = "VAZ", Model = "2110" },
                new Car { VehicleCount = 11, Make = "Audi", Model = "e-tron" },
                new Car { VehicleCount = 5, Make = "Audi", Model = "A4" },
                new Car { VehicleCount = 8, Make = "Audi", Model = "A5" },
                new Car { VehicleCount = 5, Make = "Audi", Model = "A6" },
                new Car { VehicleCount = 15, Make = "Audi", Model = "A7" },
                new Car { VehicleCount = 1, Make = "Audi", Model = "A8" },
                new Car { VehicleCount = 5, Make = "Audi", Model = "Q3" },
                new Car { VehicleCount = 23, Make = "Ford", Model = "Focus" },
                new Car { VehicleCount = 4, Make = "Ford", Model = "Cargo" }
            };
        }
    }
}