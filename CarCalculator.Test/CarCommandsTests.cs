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
            var cars = Stubs.InitCars();
            var command = new CountTypesCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total number of makes: 6 (Nissan, Toyota, VAZ, Audi, Volvo, Ford)", result);
        }

        [Fact]
        public void TestCountCarsCommand()
        {
            var cars = Stubs.InitCars();
            var command = new CountCarsCommand();

            var result = command.Execute(cars);

            Assert.Equal("Total amount of cars: 117", result);
        }

        [Fact]
        public void TestCalcAveragePriceCommand()
        {
            var cars = Stubs.InitCars();
            var command = new CalcAverageCarsCommand();

            var result = command.Execute(cars);

            Assert.Equal("Average price: 13028", result);
        }

        [Fact]
        public void TestCalcAveragePriceByTypeCommand()
        {
            var cars = Stubs.InitCars();
            var command = new CalcAverageCarsByTypeCommand("Ford");

            var result = command.Execute(cars);

            Assert.Equal("Average price: 23500", result);
        }
    }
}