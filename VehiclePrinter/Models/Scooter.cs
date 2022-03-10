namespace VehiclePrinter.Models;

public class Scooter : Vehicle
{
    public int SeatCount { get; init; }

    public bool HasAlarm { get; init; }
    public string HasAlarmPrefix => HasAlarm ? ", Alarm" : string.Empty;

    public override string ToString()
    {
        return base.ToString() + @$"
Seats: {SeatCount}{HasAlarmPrefix}";
    }


}