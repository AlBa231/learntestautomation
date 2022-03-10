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
            return @$"{Make} {Model} {Engine}.
{Chassis},
{Transmission}";
        }
    }
}
