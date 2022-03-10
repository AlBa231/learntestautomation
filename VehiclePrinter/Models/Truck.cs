namespace VehiclePrinter.Models;

public class Truck : Vehicle
{
    public int Height { get; init; }
    public int Width { get; init; }

    public override string ToString()
    {
        return base.ToString() + $@"
Dimensions (HxW): {Height}x{Width}";
    }
}