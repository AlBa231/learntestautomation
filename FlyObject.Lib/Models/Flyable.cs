using FlyObject.Lib.Restrictions;

namespace FlyObject
{
    public abstract class Flyable : IFlyable
    {
        protected PointZ CurrentPosition { get; private set; } = PointZ.Zero;

        protected PointZ NewPosition { get; private set; } = PointZ.Zero;

        public int Speed { get; init; }

        /// <summary>
        /// The distance between CurrentPosition and NewPosition.
        /// </summary>
        internal double Distance => NewPosition - CurrentPosition;

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
            NewPosition = newPoint;
            CheckIsFlyRestricted();
            return GetFlyTimeWithoutRestrictions();
        }

        protected abstract double GetFlyTimeWithoutRestrictions();

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
