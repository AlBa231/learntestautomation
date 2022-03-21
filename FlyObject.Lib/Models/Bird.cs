namespace FlyObject;

public class Bird : Flyable
{
    public override double GetFlyTime(PointZ newPoint)
    {
        var diff = newPoint - CurrentPosition;

        return Math.Round(diff / Speed, 2);
    }
}