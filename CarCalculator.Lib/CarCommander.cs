namespace CarCalculator.Lib
{
    public class CarCommander
    {
        public static CarCommander Instance { get; } = new();
        private readonly List<Car> cars = new ();

        private CarCommander(){}

        public void AddCar(params Car[] addingCars)
        {
            cars.AddRange(addingCars);
        }

        public void ExecuteCommand(ICalculatorCommand countTypesCommand)
        {
            Console.WriteLine();
            var result = countTypesCommand.Execute(cars);
            if (result != null)
                Console.WriteLine(result);
        }
    }
}