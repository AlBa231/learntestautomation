using Xunit;

namespace FlyObject.Test
{
    public class PointZTests
    {
        [Fact]
        public void TestPointZDiff_Equals()
        {
            var start = new PointZ(10, 10, 10);
            var end = new PointZ(20, 20, 20);
            Assert.Equal(17.32, end - start);
        }

        [Fact]
        public void TestPointZDiff_Equals2()
        {
            var start = new PointZ(10, 10, 10);
            var end = new PointZ(25, 34, 64);
            Assert.Equal(60.97, end - start);
        }
    }
}
