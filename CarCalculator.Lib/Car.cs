namespace CarCalculator.Lib;

public class Car
{
    public string Make { get; init; } = default!;
    public string Model { get; init; } = default!;

    public int VehicleCount { get; set; }
    public int VehiclePrice { get; set; }
}