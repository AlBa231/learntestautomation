namespace FlyObject
{
    public class Drone : Flyable
    {
        private const int DefaultStartSpeed = 10;

        /// <summary>
        /// The timeout when drone need to hang for <see cref="HangTime"/>.
        /// </summary>
        public TimeSpan HangTimeout { get; set; } = TimeSpan.FromMinutes(10);

        /// <summary>
        /// The time to hang for Drone after <see cref="HangTimeout"/> elapsed.
        /// </summary>
        public TimeSpan HangTime { get; set; } = TimeSpan.FromMinutes(1);

        public int Speed { get; init; } = DefaultStartSpeed;

        public override double GetFlyTime(PointZ newPoint)
        {
            var distance = newPoint - CurrentPosition;

            var timeWithoutHang = distance / Speed;

            var hangTime = CalculateHangTime(timeWithoutHang);


            return Math.Round(distance / Speed + hangTime, 2);
        }

        private double CalculateHangTime(double timeWithoutHang)
        {
            var hangCount = (int)(timeWithoutHang / HangTimeout.TotalHours);

            var hangTime = hangCount * HangTime;

            if (IsLastHangAtFinish(timeWithoutHang, hangTime))
                hangTime = hangTime.Add(- HangTime);
            return hangTime.TotalHours;
        }

        private static bool IsLastHangAtFinish(double timeWithoutHang, TimeSpan hangTime)
        {
            return timeWithoutHang * 60 % hangTime.TotalMinutes == 0;
        }
    }
}
