using FlyObject.Lib.Restrictions;
using Xunit;

namespace FlyObject.Test
{
    public class RestrictionListTests
    {
        [Fact]
        public void TestAddSameTypeRestrictions()
        {
            var restrictions = new RestrictionList
            {
                new MinSpeedRestriction(0),
                new MinSpeedRestriction(2),
                new MinSpeedRestriction(5)
            };
            
            Assert.Single(restrictions);
        }

        [Fact]
        public void TestAddSameTypeValidRestrictionRestrictions()
        {
            var restrictions = new RestrictionList
            {
                new MinSpeedRestriction(0),
                new MinSpeedRestriction(2),
                new MinSpeedRestriction(5),
                new MinSpeedRestriction(3)
            };

            var minSpeedRestriction = restrictions.Find<MinSpeedRestriction>();
            
            Assert.NotNull(minSpeedRestriction);

            Assert.Equal(3, minSpeedRestriction!.MinimalSpeed);
        }
    }
}
