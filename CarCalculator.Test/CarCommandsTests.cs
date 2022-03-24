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
        public void TestCountTypesCommand()
        {
            var cars = InitCars();
            var command = new CountTypesCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total number of makes: 5 (Nissan, Toyota, VAZ, Audi, Ford)", result);
        }

        [Fact]
        public void TestCountCarsCommand()
        {
            var cars = InitCars();
            var command = new CountCarsCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total amount of cars: 117", result);
        }

        [Fact]
        public void TestCalcAveragePriceCommand()
        {
            var cars = InitCars();
            var command = new CalcAverageCarsCommand();

            var result = command.Execute(cars);

            Assert.Equal("Average price: 13028", result);
        }

        [Fact]
        public void TestCalcAveragePriceByTypeCommand()
        {
            var cars = InitCars();
            var command = new CalcAverageCarsByTypeCommand("Ford");

            var result = command.Execute(cars);

            Assert.Equal("Average price: 23500", result);
        }

        private static Car[] InitCars()
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
                new Car { VehiclePrice = 9000, VehicleCount = 5, Make = "Audi", Model = "A6" },
                new Car { VehiclePrice = 6000, VehicleCount = 15, Make = "Audi", Model = "A7" },
                new Car { VehiclePrice = 7000, VehicleCount = 1, Make = "Audi", Model = "A8" },
                new Car { VehiclePrice = 11000, VehicleCount = 5, Make = "Audi", Model = "Q3" },
                new Car { VehiclePrice = 18000, VehicleCount = 23, Make = "Ford", Model = "Focus" },
                new Car { VehiclePrice = 29000, VehicleCount = 4, Make = "Ford", Model = "Cargo" }
            };
        }
    }
}