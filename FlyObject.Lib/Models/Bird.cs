namespace FlyObject;

public class Bird : Flyable
{
    protected override double GetFlyTimeWithoutRestrictions(double distance)
    {
        return Math.Round(distance / Speed, 2);
    }
}