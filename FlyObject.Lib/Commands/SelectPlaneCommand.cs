using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands;

[CommandKey('P', "Select Plane flyable")]
public class SelectPlaneCommand : IFlyableCommand
{
    public IFlyable Execute()
    {
        return new Plane();
    }
}