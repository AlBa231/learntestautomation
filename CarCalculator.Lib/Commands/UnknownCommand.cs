namespace CarCalculator.Lib
{
    public class UnknownCommand: ICalculatorCommand
    {
        public string Execute(IEnumerable<Car> cars)
        {
            return "The command is unknown";
        }
    }
}
