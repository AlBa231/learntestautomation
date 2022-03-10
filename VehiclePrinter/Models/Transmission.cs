namespace VehiclePrinter.Models;

public class Transmission
{
    public TransmissionType Type { get; set; }
    public int GearsNumber { get; set; }
    public string Manufacturer { get; set; } = null!;

    public override string ToString()
    {
        return $"{Type}, {GearsNumber} gears, {Manufacturer}";
    }
}