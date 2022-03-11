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
            var diff = end - start;
            Assert.Equal(10, diff.X);
            Assert.Equal(10, diff.Y);
            Assert.Equal(10, diff.Z);
        }


        [Fact]
        public void TestPointZDiff_SmallNumbers()
        {
            var start = new PointZ(10, 10, 10);
            var end = new PointZ(25, 23, 21);
            var diff = end - start;
            Assert.Equal(15, diff.X);
            Assert.Equal(13, diff.Y);
            Assert.Equal(11, diff.Z);
        }


        [Fact]
        public void TestPointZDiff_NegativeNumbers()
        {
            var start = new PointZ(10, 10, 10);
            var end = new PointZ(5, 3, 7);
            var diff = end - start;
            Assert.Equal(-5, diff.X);
            Assert.Equal(-7, diff.Y);
            Assert.Equal(-3, diff.Z);
        }
    }
}
