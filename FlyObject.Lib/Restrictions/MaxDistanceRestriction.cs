using FlyObject.Lib.Models;

namespace FlyObject.Lib.Restrictions;

public class MaxDistanceRestriction : IRestriction
{
    public double MaxDistance { get; }
    public string? ErrorMessage { get; private set; }

    public MaxDistanceRestriction(double maxDistance)
    {
        MaxDistance = maxDistance;
    }

    public bool Validate(Flyable flyable)
    {
        if (flyable.Distance > MaxDistance)
        {
            ErrorMessage = $"Distance {flyable.Distance} is more than {MaxDistance}.";
            return false;
        }
        return true;
    }
}