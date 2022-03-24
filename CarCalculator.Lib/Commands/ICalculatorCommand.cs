namespace CarCalculator.Lib
{
    public interface ICalculatorCommand
    {
        public string? Execute(IEnumerable<Car> cars);
    }
}
