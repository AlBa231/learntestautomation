namespace CarCalculator.Lib;

public class CountCarsCommand : ICalculatorCommand
{
    public string Execute(IEnumerable<Car> cars)
    {
        var count = cars.Sum(car => car.VehicleCount);

        return $"Total amount of cars: {count}";
    }
}