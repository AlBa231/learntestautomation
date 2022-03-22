using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    [CommandKey('Q', "Quit")]
    public class QuitCommand : IFlyableCommand
    {
        public IFlyable Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
