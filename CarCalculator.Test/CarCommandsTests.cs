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
        public void TestCountCars()
        {
            var cars = InitCars();
            var command = new CountTypesCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total number of makes: 5 (Nissan, Toyota, VAZ, Audi, Ford)", result);
        }

        private static Car[] InitCars()
        {
            return new[]
            {
                new Car { Make = "Nissan", Model = "Versa" },
                new Car { Make = "Nissan", Model = "Sentra" },
                new Car { Make = "Nissan", Model = "Altima" },
                new Car { Make = "Toyota", Model = "Avalon" },
                new Car { Make = "Toyota", Model = "Belta" },
                new Car { Make = "Toyota", Model = "Camry" },
                new Car { Make = "VAZ", Model = "2106" },
                new Car { Make = "VAZ", Model = "2107" },
                new Car { Make = "VAZ", Model = "2110" },
                new Car { Make = "Audi", Model = "e-tron" },
                new Car { Make = "Audi", Model = "A4" },
                new Car { Make = "Audi", Model = "A5" },
                new Car { Make = "Audi", Model = "A6" },
                new Car { Make = "Audi", Model = "A7" },
                new Car { Make = "Audi", Model = "A8" },
                new Car { Make = "Audi", Model = "Q3" },
                new Car { Make = "Ford", Model = "Focus" },
                new Car { Make = "Ford", Model = "Cargo" }
            };
        }
    }
}