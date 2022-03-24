namespace CarCalculator.Lib
{
    public class CountTypesCommand: ICalculatorCommand
    {
        public string Execute(IEnumerable<Car> cars)
        {
            var distinctTypes = cars.Select(car => car.Make).Distinct().ToList();
            var typesString = string.Join(", ", distinctTypes);

            return $"Total number of makes: {distinctTypes.Count} ({typesString})";
        }
    }
}
