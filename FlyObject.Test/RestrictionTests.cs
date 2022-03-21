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
    }
}
