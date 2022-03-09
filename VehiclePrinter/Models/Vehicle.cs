namespace VehiclePrinter.Models
{
    public abstract class Vehicle
    {
        public VehicleEngine Engine { get; init; } = null!;
        public VehicleChassis Chassis { get; init; } = null!;
        public Transmission Transmission { get; init; } = null!;
        public string Model { get; set; } = null!;
        public string Make { get; set; } = null!;

        public override string ToString()
        {
            return FormattableString.Invariant(@$"{Make} {Model} {Engine.RoundedCapacity} ({Engine.Power} hp), {Engine.Type}.
{Chassis.WheelCount} wheels, {Chassis.MaxLoad} kg, {Chassis.Number},
{Transmission.Type}, {Transmission.GearsNumber} gears, {Transmission.Manufacturer}");
        }
    }

    public class Car : Vehicle
    {
    }

    public class Transmission
    {
        public TransmissionType Type { get; set; }
        public int GearsNumber { get; set; }
        public string Manufacturer { get; set; }
    }

    public class VehicleChassis
    {
        public int WheelCount { get; set; }
        public string Number { get; set; }
        public int MaxLoad { get; set; }
    }

    public class VehicleEngine
    {
        public int Power { get; set; }
        public int Capacity { get; set; }
        public EngineType Type { get; set; }
        public string SerialNumber { get; set; }
        public double RoundedCapacity => Math.Round(Capacity / 1000f, 1);
    }

    public enum EngineType
    {
        Gasoline,
        Diesel
    }

    public enum TransmissionType
    {
        Manual,
        Automatic
    }
}
