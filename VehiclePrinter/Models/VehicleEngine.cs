namespace VehiclePrinter.Models;

public class VehicleEngine
{
    public int Power { get; set; }
    public int Capacity { get; set; }
    public EngineType Type { get; set; }
    public string SerialNumber { get; set; } = null!;
    public double RoundedCapacity => Math.Round(Capacity / 1000f, 1);

    public override string ToString()
    {
        return FormattableString.Invariant(@$"{RoundedCapacity} ({Power} hp), {Type}");
    }
}