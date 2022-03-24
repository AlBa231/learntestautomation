namespace CarCalculator.Lib;

public class QuitCommand : ICalculatorCommand
{
    public string Execute(IEnumerable<Car> cars)
    {
        Environment.Exit(0);
        return null;
    }
}