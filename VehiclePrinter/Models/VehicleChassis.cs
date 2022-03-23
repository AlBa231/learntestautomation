namespace VehiclePrinter.Models;

public class VehicleChassis
{
    public int WheelCount { get; set; }
    public string Number { get; set; } = null!;
    public int MaxLoad { get; set; }

    public override string ToString()
    {
        return $"{WheelCount} wheels, {MaxLoad} kg, {Number}";
    }
}