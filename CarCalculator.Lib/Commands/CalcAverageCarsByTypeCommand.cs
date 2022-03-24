namespace CarCalculator.Lib;

public class CalcAverageCarsByTypeCommand : ICalculatorCommand
{
    private readonly string make;

    public CalcAverageCarsByTypeCommand(string make)
    {
        this.make = make ?? throw new ArgumentNullException(nameof(make));
    }

    public string Execute(IEnumerable<Car> cars)
    {
        var filteredCars = cars.Where(car => make.Equals(car.Make, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!filteredCars.Any())
            return $"Make {make} is not found.";
        var price = Math.Round(filteredCars.Average(car => car.VehiclePrice));

        return $"Average price: {price}";
    }
}