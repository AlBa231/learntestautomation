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

    public class Bird : Flyable
    {
        /// <summary>
        /// The Bird speed (km/hrs).
        /// </summary>
        public int Speed { get; set; }

        public override double GetFlyTime(PointZ newPoint)
        {
            var diff = newPoint - CurrentPosition;

            return Math.Round(diff / Speed, 2);
        }


    }
}
