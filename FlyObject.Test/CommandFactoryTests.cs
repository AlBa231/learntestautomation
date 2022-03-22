using FlyObject.Lib.Commands;
using FlyObject.Lib.Models;
using Xunit;

namespace FlyObject.Test
{
    public class CommandFactoryTests
    {
        [Fact]
        public void TestFindCommand()
        {
            var commandKey = 'Q';

            var commandInfo = CommandFactory.FindCommand(commandKey);

            Assert.NotNull(commandInfo);
            Assert.Equal(typeof(QuitCommand), commandInfo.CommandType);
        }
        
        [Fact]
        public void TestFindBirdCommand()
        {
            var commandKey = 'B';

            var commandInfo = CommandFactory.FindCommand(commandKey);

            Assert.NotNull(commandInfo);
            Assert.Equal(typeof(SelectBirdCommand), commandInfo.CommandType);
        }

        [Fact]
        public void TestCommandCreateBird()
        {
            var commandKey = 'B';

            var commandInfo = CommandFactory.FindCommand(commandKey);
            var bird = commandInfo.Execute(null, new TestDummyPrinter());

            Assert.NotNull(bird);
            Assert.IsType<Bird>(bird);
        }

        [Fact]
        public void TestFindDroneCommand()
        {
            var commandKey = 'D';

            var commandInfo = CommandFactory.FindCommand(commandKey);

            Assert.NotNull(commandInfo);
            Assert.Equal(typeof(SelectDroneCommand), commandInfo.CommandType);
        }

        [Fact]
        public void TestCommandCreateDrone()
        {
            var commandKey = 'D';

            var commandInfo = CommandFactory.FindCommand(commandKey);
            var drone = commandInfo.Execute(null, new TestDummyPrinter());

            Assert.NotNull(drone);
            Assert.IsType<Drone>(drone);
        }
        
        [Fact]
        public void TestFindPlaneCommand()
        {
            var commandKey = 'P';

            var commandInfo = CommandFactory.FindCommand(commandKey);

            Assert.NotNull(commandInfo);
            Assert.Equal(typeof(SelectPlaneCommand), commandInfo.CommandType);
        }

        [Fact]
        public void TestCommandCreatePlane()
        {
            var commandKey = 'P';

            var commandInfo = CommandFactory.FindCommand(commandKey);
            var plane = commandInfo.Execute(null, new TestDummyPrinter());

            Assert.NotNull(plane);
            Assert.IsType<Plane>(plane);
        }
    }
}
