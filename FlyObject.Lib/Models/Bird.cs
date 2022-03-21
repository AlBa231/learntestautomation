using FlyObject.Lib.Restrictions;

namespace FlyObject.Lib.Models;

public class Bird : Flyable
{
    private const int MaxSpeed = 20;

    public Bird()
    {
        Restrictions.Add(new MaxSpeedRestriction(MaxSpeed));
    }

    protected override double GetFlyTimeWithoutRestrictions()
    {
        return Math.Round(Distance / Speed, 2);
    }
}