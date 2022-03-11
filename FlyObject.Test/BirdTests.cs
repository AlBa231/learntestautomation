using Xunit;

namespace FlyObject.Test
{
    public class BirdTests
    {
        [Fact]
        public void TestGetFlyTimeForBird()
        {
            var bird = new Bird
            {
                Speed = 15
            };

            bird.FlyTo(new PointZ(10, 10, 10));

            Assert.Equal(4.06, bird.GetFlyTime(new PointZ(25, 34, 64)));
        }
    }
}