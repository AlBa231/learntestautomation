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
            var flyable = new Bird();

            var command = CommandFactory.CreateCommand(flyable, commandKey);

            Assert.NotNull(command);
            Assert.IsType<QuitCommand>(command);
        }
    }
}
