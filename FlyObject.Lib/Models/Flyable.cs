using FlyObject.Lib.Restrictions;

namespace FlyObject
{
    public abstract class Flyable : IFlyable
    {
        protected PointZ CurrentPosition { get; private set; } = PointZ.Zero;
        public int Speed { get; init; }

        public List<IRestriction> Restrictions { get; } = new();

        protected Flyable()
        {
            Restrictions.Add(new MinSpeedRestriction(0));
        }

        public void FlyTo(PointZ newPoint)
        {
            CurrentPosition = newPoint;
        }

        public double GetFlyTime(PointZ newPoint)
        {
            CheckIsFlyRestricted();
            return GetFlyTimeWithoutRestrictions(newPoint - CurrentPosition);
        }

        protected abstract double GetFlyTimeWithoutRestrictions(double distance);

        private void CheckIsFlyRestricted()
        {
            var allInvalidRestrictions = Restrictions.Where(IsFailedRestriction).ToList();

            if (allInvalidRestrictions.Count > 0)
                throw new FlyableRestrictionException(allInvalidRestrictions);
        }

        private bool IsFailedRestriction(IRestriction restriction)
        {
            return !restriction.Validate(this);
        }


    }
}
