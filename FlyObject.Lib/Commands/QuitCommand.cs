using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    [CommandKey('Q')]
    public class QuitCommand : IFlyableCommand
    {
        public IFlyable? Flyable { get; set; }

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
