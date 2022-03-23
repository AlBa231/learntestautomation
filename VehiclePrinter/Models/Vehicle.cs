namespace VehiclePrinter.Models
{
    public abstract class Vehicle
    {
        private readonly VehicleEngine _engine = null!;
        private readonly VehicleChassis chassis = null!;
        private readonly Transmission transmission = null!;

        public VehicleEngine Engine
        {
            get => _engine;
            init { _engine = value; Validate(); }
    }

        public VehicleChassis Chassis
        {
            get => chassis;
            init { chassis = value; Validate(); }
        }

        public Transmission Transmission
        {
            get => transmission;
            init { transmission = value; Validate(); }
        }

        public string Model { get; set; } = null!;
        public string Make { get; set; } = null!;

        public override string ToString()
        {
            return @$"{Make} {Model} {Engine}.
{Chassis},
{Transmission}";
        }

        protected virtual void Validate() {}
    }
}
