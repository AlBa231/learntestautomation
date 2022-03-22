using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;
using Moq;
using Xunit;

namespace FlyObject.Test;

public class GetFlyTimeToCommandTests
{
    [Fact]
    public void TestFindGetFlyTimeToCommand()
    {
        var commandKey = 'G';

        var commandInfo = CommandFactory.FindCommand(commandKey);

        Assert.NotNull(commandInfo);
        Assert.Equal(typeof(GetFlyTimeToCommand), commandInfo.CommandType);
    }

    [Fact]
    public void TestGetFlyTimeToCommand()
    {
        var commandKey = 'G';
        var stubPrinter = new Mock<IFlyablePrinter>();
        stubPrinter.Setup(p => p.ReadLine()).Returns("100 0 0");
        var bird = new Bird { Speed = 20 };

        var commandInfo = CommandFactory.FindCommand(commandKey);
        commandInfo.Execute(bird, stubPrinter.Object);
        
        stubPrinter.Verify(p => p.WriteLine("The time for fly is 5"));
    }
}