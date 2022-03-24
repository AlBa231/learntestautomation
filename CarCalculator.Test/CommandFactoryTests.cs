using System.Linq;
using CarCalculator.Lib;
using Xunit;

namespace CarCalculator.Test
{
    public class CommandFactoryTests
    {
        [Fact]
        public void TestFindCountTypesCommand()
        {
            var commandWord = CommandFactory.CommandCountTypes;

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<CountTypesCommand>(command);
        }
        [Fact]
        public void TestFindCountAllCommand()
        {
            var commandWord = CommandFactory.CommandCountAll;

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<CountCarsCommand>(command);
        }

        [Fact]
        public void TestFindAveragePriceCommand()
        {
            var commandWord = CommandFactory.CommandAveragePrice;

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<CalcAverageCarsCommand>(command);
        }

        [Fact]
        public void TestFindAveragePriceForTypeCommand()
        {
            var commandWord = CommandFactory.CommandAveragePrice + " ford";
            var cars = Stubs.InitCars();
            CarCommander.Instance.AddCar(cars.ToArray());

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<CalcAverageCarsByTypeCommand>(command);
        }

        [Fact]
        public void TestFindUnknownCommand()
        {
            var commandWord = "calc price";

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<UnknownCommand>(command);
        }
        [Fact]
        public void TestFindQuit()
        {
            var commandWord = CommandFactory.CommandQuit;

            var command = CommandFactory.FindCommand(commandWord);

            Assert.IsType<QuitCommand>(command);
        }

        [Fact]
        public void TestCalcAveragePriceCommandFromFactory()
        {
            var commandWord = CommandFactory.CommandAveragePrice + " volvo";
            var cars = Stubs.InitCars().ToArray();
            CarCommander.Instance.AddCar(cars);

            var command = CommandFactory.FindCommand(commandWord);
            var result = command.Execute(cars);

            Assert.Equal("Average price: 7500", result);
        }

        [Fact]
        public void TestCalcAveragePriceForUnknownTypeCommandFromFactory()
        {
            var commandWord = CommandFactory.CommandAveragePrice + " rolls";
            var cars = Stubs.InitCars().ToArray();
            CarCommander.Instance.AddCar(cars);

            var command = CommandFactory.FindCommand(commandWord);
            var result = command.Execute(cars);

            Assert.Equal("Make rolls is not found.", result);
        }
    }
}
