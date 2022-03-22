using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;
using Moq;
using Xunit;

namespace FlyObject.Test;

public class SetFlyableMaxDistanceCommandTests
{
    [Fact]
    public void TestFindSetFlyableMaxSpeedCommand()
    {
        var commandKey = 'T';

        var commandInfo = CommandFactory.FindCommand(commandKey);

        Assert.NotNull(commandInfo);
        Assert.Equal(typeof(SetFlyableMaxDistanceCommand), commandInfo.CommandType);
    }

    [Fact]
    public void TestSetFlyableMaxSpeedRestrictionCommand()
    {
        var commandKey = 'T';
        var stubPrinter = new Mock<IFlyablePrinter>();
        stubPrinter.Setup(p => p.ReadNumber()).Returns(10);
        var bird = new Bird { Speed = 15 };

        var commandInfo = CommandFactory.FindCommand(commandKey);
        commandInfo.Execute(bird, stubPrinter.Object);

        Assert.Throws<FlyableRestrictionException>(() => bird.GetFlyTime(new PointZ("0 11 0")));
    }
}