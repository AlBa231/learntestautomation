using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;
using Moq;
using Xunit;

namespace FlyObject.Test
{
    public class SetFlyableMaxSpeedCommandTests
    {
        [Fact]
        public void TestFindSetFlyableMaxSpeedCommand()
        {
            var commandKey = 'M';

            var commandInfo = CommandFactory.FindCommand(commandKey);

            Assert.NotNull(commandInfo);
            Assert.Equal(typeof(SetFlyableMaxSpeedCommand), commandInfo.CommandType);
        }

        [Fact]
        public void TestSetFlyableMaxSpeedRestrictionCommand()
        {
            var commandKey = 'M';
            var stubPrinter = new Mock<IFlyablePrinter>();
            stubPrinter.Setup(p => p.ReadNumber()).Returns(14);
            var bird = new Bird { Speed = 15 };

            var commandInfo = CommandFactory.FindCommand(commandKey);
            commandInfo.Execute(bird, stubPrinter.Object);

            Assert.Throws<FlyableRestrictionException>(() => bird.GetFlyTime(new PointZ("4 5 3")));
        }
    }
}
