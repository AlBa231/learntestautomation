namespace CarCalculator.Lib;

public class CalcAverageCarsCommand : ICalculatorCommand
{
    public string Execute(IEnumerable<Car> cars)
    {
        var price = Math.Round(cars.Average(car => car.VehiclePrice));

        return $"Average price: {price}";
    }
}