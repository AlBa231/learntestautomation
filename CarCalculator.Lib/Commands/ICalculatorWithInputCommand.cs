namespace CarCalculator.Lib;

public interface ICalculatorWithInputCommand : ICalculatorCommand
{
    public IInput Input { get; set; }
}