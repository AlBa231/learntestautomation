namespace CarCalculator.Lib
{
    public class CarCommander
    {
        public static CarCommander Instance { get; } = new();
        private readonly List<Car> cars = new ();
        private CarCommander(){}

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void ExecuteCommand(ICalculatorCommand countTypesCommand)
        {
            var result = countTypesCommand.Execute(cars);
            if (result != null)
                Console.WriteLine(result);
        }
    }
}