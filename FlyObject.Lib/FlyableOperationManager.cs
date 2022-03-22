using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;

namespace FlyObject.Lib
{
    public abstract class FlyableOperationManager
    {
        private readonly IFlyablePrinter flyablePrinter;
        private IFlyable? currentFlyable;

        protected FlyableOperationManager(IFlyablePrinter flyablePrinter)
        {
            this.flyablePrinter = flyablePrinter;
        }

        protected void PrintOperations()
        {
            flyablePrinter.Clear();
            flyablePrinter.WriteLine("Lets check speed of:");

            flyablePrinter.WriteLine("1 - Bird");
            flyablePrinter.WriteLine("2 - Plane");
            flyablePrinter.WriteLine("3 - Drone");

            flyablePrinter.WriteLine("Q - Quit");

            flyablePrinter.WriteLine();
        }

        protected void TryProcessOperation()
        {
            try
            {
                ProcessOperation();
            }
            catch (FlyableException e)
            {
                flyablePrinter.WriteLine($"Error - {e.Message}. Return to main menu.");
            }
        }

        private void ProcessOperation()
        {
            var commandKey = char.ToUpper(flyablePrinter.ReadChar());
            var command = CommandFactory.CreateCommand(currentFlyable, commandKey);
            command.Execute();
            
            currentFlyable = FlyableFactory.GetFlyable(commandKey);

            PrintFlyableInfo();

            var flyableCommand = flyablePrinter.ReadChar();
        }

        private void PrintFlyableInfo()
        {
            flyablePrinter.Clear();
            flyablePrinter.WriteLine($"Selected {currentFlyable.GetType().Name}");
            flyablePrinter.WriteLine($"Speed - {currentFlyable.Speed}");

            flyablePrinter.WriteLine();
            flyablePrinter.WriteLine("Select operation:");
            flyablePrinter.WriteLine("1 - set fly start point");
            flyablePrinter.WriteLine("2 - calculate fly time");
            flyablePrinter.WriteLine("3 - set fly speed");
            flyablePrinter.WriteLine("R - show restrictions");

            //custom commands
            //bird
            flyablePrinter.WriteLine("4 - set fly speed");
        }
    }
}
