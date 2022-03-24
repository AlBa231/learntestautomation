namespace CarCalculator.Lib
{
    public static class CommandFactory
    {
        public const string CommandCountTypes = "count types";
        public const string CommandCountAll = "count all";
        public const string CommandAveragePrice = "average price";
        public const string CommandQuit = "quit";

        public static ICalculatorCommand FindCommand(string commandPrefix)
        {
            return commandPrefix switch
            {
                CommandCountTypes => new CountTypesCommand(),
                CommandCountAll => new CountCarsCommand(),
                CommandAveragePrice => new CalcAverageCarsCommand(),
                { } withFilter when commandPrefix.StartsWith("average price") => new CalcAverageCarsByTypeCommand(
                    withFilter.Substring("average price".Length).Trim()),
                CommandQuit => new QuitCommand(),
                _ => new UnknownCommand()
            };
        }
    }
}
