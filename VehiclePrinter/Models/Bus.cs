namespace VehiclePrinter.Models;

public class Bus : Vehicle
{
    public int PassengerSeatCount { get; init; }

    public int HandicappedSeatCount { get; init; }

    public bool HasToilet { get; init; }

    public override string ToString()
    {
        return base.ToString() + @$"
Seats: {PassengerSeatCount} + {HandicappedSeatCount}{HasToiletPrefix}";
    }

    private string HasToiletPrefix => HasToilet ? ", Toilet" : string.Empty;
}
