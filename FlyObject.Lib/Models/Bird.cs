using FlyObject.Lib.Restrictions;

namespace FlyObject;

public class Bird : Flyable
{
    private const int MaxSpeed = 20;

    public Bird()
    {
        Restrictions.Add(new MaxSpeedRestriction(MaxSpeed));
    }

    protected override double GetFlyTimeWithoutRestrictions(double distance)
    {
        return Math.Round(distance / Speed, 2);
    }
}