using FlyObject.Lib.Models;

namespace FlyObject.Lib.Restrictions;

public class MaxSpeedRestriction : IRestriction
{
    public int MaxSpeed { get; }

    public string? ErrorMessage { get; private set; }

    public MaxSpeedRestriction(int maxSpeed)
    {
        MaxSpeed = maxSpeed;
    }

    public bool Validate(Flyable flyable)
    {
        if (flyable.Speed > MaxSpeed)
        {
            ErrorMessage = $"Speed {flyable.Speed} is more than {MaxSpeed}.";
            return false;
        }
        return true;
    }
}