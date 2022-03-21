using FlyObject.Lib;
using FlyObject.Lib.Models;
using Xunit;

namespace FlyObject.Test
{
    public class FlyableFactoryTests
    {
        [Fact]
        public void TestFlyableIsBird()
        {
            var bird = FlyableFactory.GetFlyable(1);

            Assert.IsType<Bird>(bird);
        }

        [Fact]
        public void TestFlyableIsPlane()
        {
            var plane = FlyableFactory.GetFlyable(2);

            Assert.IsType<Plane>(plane);
        }

        [Fact]
        public void TestFlyableIsDrone()
        {
            var drone = FlyableFactory.GetFlyable(3);

            Assert.IsType<Drone>(drone);
        }


        [Fact]
        public void TestFlyableException()
        {
            Assert.Throws<FlyableException>(() => FlyableFactory.GetFlyable(0));
        }


        [Fact]
        public void TestFlyableIsBirdChar()
        {
            var bird = FlyableFactory.GetFlyable('1');

            Assert.IsType<Bird>(bird);
        }

        [Fact]
        public void TestFlyableIsPlaneChar()
        {
            var plane = FlyableFactory.GetFlyable('2');

            Assert.IsType<Plane>(plane);
        }

        [Fact]
        public void TestFlyableIsDroneChar()
        {
            var drone = FlyableFactory.GetFlyable('3');

            Assert.IsType<Drone>(drone);
        }


        [Fact]
        public void TestFlyableExceptionInvalidChar()
        {
            Assert.Throws<FlyableException>(() => FlyableFactory.GetFlyable('a'));
        }

        [Fact]
        public void TestFlyableExceptionInvalidIndexChar()
        {
            Assert.Throws<FlyableException>(() => FlyableFactory.GetFlyable('0'));
        }
    }
}
