using System.Linq;
using FlyObject.Lib.Restrictions;
using Xunit;

namespace FlyObject.Test
{
    public class RestrictionTests
    {
        [Fact]
        public void TestAddWithReplaceRestriction()
        {
            var flyable = new Bird { Speed = 1 };
            flyable.Restrictions.Add(new MinSpeedRestriction(2));

            Assert.Throws<FlyableRestrictionException>(() => flyable.GetFlyTime(new PointZ("1 2 3")));
        }

        [Fact]
        public void TestBirdMaxSpeedRestriction()
        {
            var flyable = new Bird { Speed = 21 };

            Assert.Throws<FlyableRestrictionException>(() => flyable.GetFlyTime(new PointZ("1 2 3")));
        }

        [Fact]
        public void TestNoRestrictionForBird()
        {
            var flyable = new Bird { Speed = 10 };
            flyable.Restrictions.RemoveAll(r => r is MinSpeedRestriction);
            flyable.Restrictions.Add(new MinSpeedRestriction(2));

            flyable.GetFlyTime(new PointZ("1 2 3"));

            var minSpeedRestriction = flyable.Restrictions.OfType<MinSpeedRestriction>().First();

            Assert.Equal(2, minSpeedRestriction.MinimalSpeed);
        }

        [Fact]
        public void TestDroneMaxRestrictionOk()
        {
            var flyable = new Drone {  };
            flyable.Restrictions.RemoveAll(r => r is MaxDistanceRestriction);
            flyable.Restrictions.Add(new MaxDistanceRestriction(20));

            flyable.GetFlyTime(new PointZ("20 0 0"));

            var maxDistanceRestriction = flyable.Restrictions.OfType<MaxDistanceRestriction>().First();

            Assert.Equal(20, maxDistanceRestriction.MaxDistance);
        }

        [Fact]
        public void TestDroneMaxRestrictionOkLongPosition()
        {
            var flyable = new Drone {  };
            flyable.Restrictions.RemoveAll(r => r is MaxDistanceRestriction);
            flyable.Restrictions.Add(new MaxDistanceRestriction(20));

            flyable.FlyTo(new PointZ("120 30 40"));

            flyable.GetFlyTime(new PointZ("140 30 40"));

            var maxDistanceRestriction = flyable.Restrictions.OfType<MaxDistanceRestriction>().First();

            Assert.Equal(20, maxDistanceRestriction.MaxDistance);
        }


        [Fact]
        public void TestDroneMaxRestrictionFailed()
        {
            var flyable = new Drone();
            flyable.Restrictions.RemoveAll(r => r is MaxDistanceRestriction);
            flyable.Restrictions.Add(new MaxDistanceRestriction(20));

            Assert.Throws<FlyableRestrictionException>(() => flyable.GetFlyTime(new PointZ("21 0 0")));
        }
    }
}
