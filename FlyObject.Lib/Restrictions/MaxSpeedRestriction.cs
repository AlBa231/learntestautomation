namespace FlyObject.Lib.Restrictions;

public class MaxSpeedRestriction : IRestriction
{
    public int MaxSpeed { get; }

    public MaxSpeedRestriction(int maxSpeed)
    {
        MaxSpeed = maxSpeed;
    }

    public bool Validate(Flyable flyable)
    {
        if (flyable.Speed > MaxSpeed) return false;
        return true;
    }
}