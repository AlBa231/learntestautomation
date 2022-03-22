using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    [CommandKey('B', "Select Bird flyable")]
    public class SelectBirdCommand: IFlyableCommand
    {
        public IFlyable Execute()
        {
            return new Bird { Speed = Random.Shared.Next(20) };
        }
    }
}
