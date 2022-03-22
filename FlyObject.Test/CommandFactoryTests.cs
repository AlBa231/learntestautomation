using FlyObject.Lib.Commands;
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

    }
}
