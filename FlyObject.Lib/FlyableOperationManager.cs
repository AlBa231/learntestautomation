using FlyObject.Lib.Commands;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;

namespace FlyObject.Lib
{
    public class FlyableOperationManager
    {
        private readonly IFlyablePrinter flyablePrinter;
        private IFlyable? currentFlyable;
        private readonly List<FlyableCommandInfo> availableCommands = new();

        public FlyableOperationManager(IFlyablePrinter flyablePrinter)
        {
            this.flyablePrinter = flyablePrinter;
        }
        
        public void Start()
        {
            while (true)
            {
                TryProcessOperation();
            }
        }

        private void TryProcessOperation()
        {
            try
            {
                ProcessOperation();
            }
            catch (FlyableException e)
            {
                currentFlyable = null;
                flyablePrinter.Clear();
                flyablePrinter.WriteLine($"Error - {e.Message}. Returning to main menu.");
                flyablePrinter.WriteLine($"Press any key to continue...");
                flyablePrinter.ReadChar();
            }
        }

        private void ProcessOperation()
        {
            PrintFlyableInfo();
            PrintFlyableRestrictions();
            PrintCommands();
            ProcessCommand();
        }

        private void PrintFlyableInfo()
        {
            if (currentFlyable == null) return;
            flyablePrinter.Clear();
            flyablePrinter.WriteLine($"Selected {currentFlyable.GetType().Name}");
            flyablePrinter.WriteLine($"Speed - {currentFlyable.Speed}");
            flyablePrinter.WriteLine();
        }
        private void PrintFlyableRestrictions()
        {
            if (currentFlyable == null) return;
            flyablePrinter.WriteLine("Restrictions:");
            foreach (var restriction in currentFlyable.Restrictions)
            {
                flyablePrinter.WriteLine($"{restriction.GetType().Name} [{restriction.Description}]");
            }
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
            currentFlyable = command.Execute(currentFlyable, flyablePrinter);
        }
    }
}
