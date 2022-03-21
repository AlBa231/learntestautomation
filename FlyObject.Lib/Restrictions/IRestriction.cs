namespace FlyObject.Lib.Restrictions
{
    public interface IRestriction
    {
        bool Validate(Flyable flyable);
    }
}
