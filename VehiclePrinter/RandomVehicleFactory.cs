using VehiclePrinter.Models;

namespace VehiclePrinter
{
    public static class RandomVehicleFactory
    {
        public static VehicleList CreateRandomVehicles(int count)
        {
            return new VehicleList(new int[count].Select(_ => RandomVehicleFactory.CreateRandomVehicle()));
        }

        public static Vehicle CreateRandomVehicle()
        {
            return Random.Shared.Next(4) switch
            {
                0 => CreateCar(),
                1 => CreateTruck(),
                2 => CreateBus(),
                3 => CreateScooter(),
                _ => throw new Exception("Value is invalid.")
            };
        }

        public static Car CreateCar()
        {
            return new Car
            {
                Engine = CreateRandomVehicleEngine(50, 200),
                Chassis = CreateRandomVehicleChassis(2, 3),
                Transmission = CreateRandomTransmission(),
                Model = RandomWord(),
                Make = RandomWord()
            };
        }

        public static Truck CreateTruck()
        {
            return new Truck
            {
                Engine = CreateRandomVehicleEngine(150, 350),
                Chassis = CreateRandomVehicleChassis(2, 5),
                Transmission = CreateRandomTransmission(),
                Model = RandomWord(),
                Make = RandomWord(),
                Height = Random.Shared.Next(2000, 4000),
                Width = Random.Shared.Next(2000, 4000),
            };
        }

        public static Bus CreateBus()
        {
            return new Bus
            {
                Engine = CreateRandomVehicleEngine(100, 200),
                Chassis = CreateRandomVehicleChassis(4, 8),
                Transmission = CreateRandomTransmission(),
                Model = RandomWord(),
                Make = RandomWord(),
                PassengerSeatCount = Random.Shared.Next(10, 100),
                HandicappedSeatCount = Random.Shared.Next(10),
                HasToilet = Random.Shared.Next(2) % 2 == 0
            };
        }

        public static Scooter CreateScooter()
        {
            return new Scooter
            {
                Engine = CreateRandomVehicleEngine(1, 15),
                Chassis = CreateRandomVehicleChassis(1, 2),
                Transmission = CreateRandomTransmission(),
                Model = RandomWord(),
                Make = RandomWord(),
                HasAlarm = Random.Shared.Next(2) % 2 == 0,
                SeatCount = Random.Shared.Next(1, 3)
            };
        }

        private static VehicleEngine CreateRandomVehicleEngine(int min = 1, int max = 300)
        {
            var power = Random.Shared.Next(min, max);
            return new VehicleEngine
            {
                Power = power,
                Capacity = power * 12,
                Type = Random.Shared.Next(2) % 2 == 0 ? EngineType.Gasoline : EngineType.Diesel,
                SerialNumber = power.GetHashCode().ToString()
            };
        }
        private static VehicleChassis CreateRandomVehicleChassis(int minWheelPairs, int maxWheelPairs)
        {
            var wheelCount = Random.Shared.Next(minWheelPairs, maxWheelPairs) * 2;
            return new VehicleChassis
            {
                WheelCount = wheelCount,
                Number = Random.Shared.Next(1000).GetHashCode().ToString(),
                MaxLoad = wheelCount * Random.Shared.Next(10, 1000)
            };
        }
        private static Transmission CreateRandomTransmission()
        {
            return new Transmission
            {
                Type = Random.Shared.Next(2) % 2 == 0 ? TransmissionType.Automatic : TransmissionType.Manual,
                GearsNumber = Random.Shared.Next(2, 10),
                Manufacturer = $"{RandomWord()} {RandomWord()}"
            };
        }


        private static string RandomWord()
        {
            var str = RandomString(Random.Shared.Next(4, 10));
            return str[0] + str.Substring(1).ToLower();
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }
    }
}
