using System.Reflection;
using FlyObject.Lib.Models;

namespace FlyObject.Lib.Commands
{
    public static class CommandFactory
    {
        private static readonly Dictionary<char, FlyableCommandInfo> AllCommands = RegisterAllTypes().ToDictionary(f=>f.CommandKey, f=>f);

        public static FlyableCommandInfo FindCommand(char commandKey)
        {
            return AllCommands[commandKey];
        }
        public static IEnumerable<FlyableCommandInfo> GetAvailableCommands(IFlyable? currentFlyable)
        {
            if (currentFlyable is not null) return AllCommands.Values.Where(val => val.IsFlyableCommand);
            return AllCommands.Values.Where(val => !val.IsFlyableCommand);
        }

        private static IEnumerable<FlyableCommandInfo> RegisterAllTypes()
        {
            var allFlyableCommandTypes = Assembly.GetExecutingAssembly().GetTypes().Where(IsFlyableCommandType);

            return allFlyableCommandTypes.Select(f => new FlyableCommandInfo(f));
        }

        private static bool IsFlyableCommandType(Type type)
        {
            if (type.IsAbstract) return false;
            return type.IsAssignableTo(typeof(IFlyableCommand));
        }
    }
}
