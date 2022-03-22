using FlyObject.Lib.Models;
using Xunit;

namespace FlyObject.Test
{
    public class DroneTests
    {
        [Fact]
        public void TestGetFlyTimeForDroneWithoutHangOnFinish()
        {
            var drone = new Drone
            {
                Speed = 10
            };

            var startPoint = new PointZ(10, 10, 10);
            var endPoint = new PointZ(50, 10, 10);

            drone.FlyTo(startPoint);
            Assert.Equal(4.38, drone.GetFlyTime(endPoint));
        }

        [Fact]
        public void TestGetFlyTimeForDroneLongDistance()
        {
            var drone = new Drone
            {
                Speed = 10
            };

            var startPoint = new PointZ(10, 10, 10);
            var endPoint = new PointZ(501, 10, 10);

            drone.FlyTo(startPoint);
            Assert.Equal(54, drone.GetFlyTime(endPoint));
        }
    }
}
