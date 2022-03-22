using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;

namespace FlyObject.Lib
{
    public abstract class FlyableOperationManager
    {
        private readonly IFlyablePrinter flyablePrinter;
        private IFlyable? currentFlyable;
        private readonly List<FlyableCommandInfo> availableCommands = new();

        protected FlyableOperationManager(IFlyablePrinter flyablePrinter)
        {
            this.flyablePrinter = flyablePrinter;
        }

        protected void TryProcessOperation()
        {
            try
            {
                ProcessOperation();
            }
            catch (FlyableException e)
            {
                currentFlyable = null;
                flyablePrinter.WriteLine($"Error - {e.Message}. Returning to main menu.");
            }
        }

        private void ProcessOperation()
        {
            PrintFlyableInfo();
            PrintCommands();
            ProcessCommand();
        }

        private void PrintFlyableInfo()
        {
            flyablePrinter.Clear();
            if (currentFlyable == null) return;
            flyablePrinter.WriteLine($"Selected {currentFlyable.GetType().Name}");
            flyablePrinter.WriteLine($"Speed - {currentFlyable.Speed}");
            flyablePrinter.WriteLine();
        }

        private void PrintCommands()
        {
            UpdateCommands();
            flyablePrinter.WriteLine("Select operation:");
            foreach (var command in availableCommands)
            {
                flyablePrinter.WriteLine($"{command.CommandKey} - {command.Description}");
            }
        }

        private void UpdateCommands()
        {
            availableCommands.Clear();
            availableCommands.AddRange(CommandFactory.GetAvailableCommands(currentFlyable));
        }

        private void ProcessCommand()
        {
            var commandKey = char.ToUpper(flyablePrinter.ReadChar());
            var command = availableCommands.FirstOrDefault(cmd => cmd.CommandKey == commandKey)
                ?? throw new FlyableException($"Command '{commandKey}' is not found.");
            currentFlyable = command.Execute(currentFlyable);
        }
    }
}
