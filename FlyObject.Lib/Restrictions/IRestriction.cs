using FlyObject.Lib.Models;

namespace FlyObject.Lib.Restrictions
{
    public interface IRestriction
    {
        string? ErrorMessage { get; }
        bool Validate(Flyable flyable);
    }
}
