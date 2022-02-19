using Xunit;

namespace FindMaxDifferentSymbols.Test
{
    public class SymbolDetectorTests
    {
        [Fact]
        public void ShouldFindValidNumberOfDifferentSymbols()
        {
            var testString = "TestSStg";

            var differentSymbolCount = new SymbolDetector(testString).DetectDifferentSymbols();

            Assert.Equal(5, differentSymbolCount);
        }

        [Fact]
        public void ShouldFindValidNumberOfDifferentSymbolsAtTheMiddleOfString()
        {
            var testString = "Test SString tthatt ccann reeepeett.";

            var differentSymbolCount = new SymbolDetector(testString).DetectDifferentSymbols();

            Assert.Equal(8, differentSymbolCount);
        }

        [Fact]
        public void ShouldFindValidNumberOfDifferentSymbolsAtTheEndString()
        {
            var testString = "Test SString";

            var differentSymbolCount = new SymbolDetector(testString).DetectDifferentSymbols();

            Assert.Equal(6, differentSymbolCount);
        }
    }
}