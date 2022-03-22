using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands;

[CommandKey('D', "Select Drone flyable")]
public class SelectDroneCommand : IFlyableCommand
{
    public IFlyable Execute()
    {
        return new Drone();
    }
}