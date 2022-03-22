using System.Reflection;
using FlyObject.Lib.FlyablePrinter;
using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    public class FlyableCommandInfo
    {
        public string Description { get; }
        public char CommandKey { get; }

        public Type CommandType { get; }

        /// <summary>
        /// True is command is designed for work with Flyable. Otherwise is global command.
        /// </summary>
        public bool IsFlyableCommand { get; }

        public FlyableCommandInfo(Type flyableCommandType)
        {
            var commandKeyAttribute = flyableCommandType.GetCustomAttribute<CommandKeyAttribute>() ??
                                      throw new FlyableException($"Command {flyableCommandType.FullName} does not implement CommandKeyAttribute.");
            CommandType = flyableCommandType;
            Description = commandKeyAttribute.Description;
            CommandKey = commandKeyAttribute.TestChar;
            IsFlyableCommand = flyableCommandType.IsAssignableTo(typeof(IFlyableRequiredCommand));
        }

        public IFlyable? Execute(IFlyable? currentFlyable, IFlyablePrinter printer)
        {
            var command = CreateCommand(currentFlyable, printer);
            return command.Execute();
        }

        private IFlyableCommand CreateCommand(IFlyable? flyable, IFlyablePrinter printer)
        {
            var command = Activator.CreateInstance(CommandType) as IFlyableCommand ?? throw new InvalidOperationException();
            if (command is IFlyableRequiredCommand flyableRequiredCommand)
                flyableRequiredCommand.Flyable = flyable;
            if (command is IFlyablePrinterCommand flyablePrinterCommand)
                flyablePrinterCommand.Printer = printer;
            return command;
        }
    }
}
