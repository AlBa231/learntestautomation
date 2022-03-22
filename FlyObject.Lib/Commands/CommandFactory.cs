using System.Reflection;
using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    public static class CommandFactory
    {
        private static readonly Dictionary<char, Type> Types = new();


        public static IFlyableCommand CreateCommand(IFlyable? flyable, char commandChar)
        {
            if (Types.Count == 0)
                RegisterAllTypes();
            if (Types.ContainsKey(commandChar))
            {
                return CreateCommand(flyable, Types[commandChar]);
            }

            throw new FlyableException($"Command for char {commandChar} is not found");
        }

        private static IFlyableCommand CreateCommand(IFlyable? flyable, Type commandType)
        {
            var command = Activator.CreateInstance(commandType) as IFlyableCommand ?? throw new InvalidOperationException();
            command.Flyable = flyable;
            return command;
        }

        private static void RegisterAllTypes()
        {
            var allFlyableCommandTypes = Assembly.GetExecutingAssembly().GetTypes().Where(IsFlyableCommandType);

            foreach (var flyableCommandType in allFlyableCommandTypes)
            {
                var commandKeyAttribute = flyableCommandType.GetCustomAttribute<CommandKeyAttribute>();
                if (commandKeyAttribute == null)
                    throw new FlyableException($"Command {flyableCommandType.FullName} does not implement CommandKeyAttribute.");
                Types.Add(commandKeyAttribute.TestChar, flyableCommandType);
            }
        }

        private static bool IsFlyableCommandType(Type type)
        {
            if (type.IsAbstract) return false;
            return type.IsAssignableTo(typeof(IFlyableCommand));
        }
    }
}
