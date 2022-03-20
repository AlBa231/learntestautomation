namespace FlyObject
{
    public abstract class Flyable : IFlyable
    {
        public PointZ CurrentPosition { get; private set; } = default!;

        public void FlyTo(PointZ newPoint)
        {
            CurrentPosition = newPoint;
        }

        public abstract double GetFlyTime(PointZ newPoint);
    }
}
