namespace FlyObject.Lib.Restrictions
{
    public class MinSpeedRestriction: IRestriction
    {
        public int MinimalSpeed { get; }

        public MinSpeedRestriction(int minimalSpeed)
        {
            MinimalSpeed = minimalSpeed;
        }

        public bool Validate(Flyable flyable)
        {
            if (flyable.Speed < MinimalSpeed) return false;
            return true;
        }
    }
}
