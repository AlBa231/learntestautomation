using System;
using FlyObject.Lib;
using Xunit;

namespace FlyObject.Test
{
    public class StringExtensionsTests
    {
        [Fact]
        public void TestSplitStringArray()
        {
            var str = "2 43 5 6";

            var intArray = str.ToIntArray();
            
            Assert.Equal(new[]{2, 43, 5, 6}, intArray);
        }

        [Fact]
        public void TestSplitStringInvalidArray()
        {
            var str = "2 d 43 5 6";
            
            Assert.Throws<FormatException>(() => str.ToIntArray());
        }
    }
}
