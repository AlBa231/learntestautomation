using Xunit;

namespace ConvertNumberToXNotation.Test
{
    public class NumberRadixConverterTests
    {
        [Fact]
        public void ShouldThrowsExceptionOnRadixLessThen2()
        {
            var invalidRadix = 1;

            Assert.Throws<NumberRadixException>(() => new NumberRadixConverter(invalidRadix));
        }

        [Fact]
        public void ShouldThrowsExceptionOnRadixMoreThen20()
        {
            var invalidRadix = 21;

            Assert.Throws<NumberRadixException>(() => new NumberRadixConverter(invalidRadix));
        }

        [Fact]
        public void ShouldConvertToRadix2()
        {
            var radix = 2;
            var initialValue = 4;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("100", convertedValue);
        }

        [Fact]
        public void ShouldConvertToRadix8()
        {
            var radix = 8;
            var initialValue = 325;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("505", convertedValue);
        }

        [Fact]
        public void ShouldConvertToRadix16()
        {
            var radix = 16;
            var initialValue = 325;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("145", convertedValue);
        }

        [Fact]
        public void ShouldConvertToRadix16WithLetters()
        {
            var radix = 16;
            var initialValue = 992;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("3E0", convertedValue);
        }

        [Fact]
        public void ShouldConvertToRadix20WithLetters()
        {
            var radix = 20;
            var initialValue = 1524;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("3G4", convertedValue);
        }

        [Fact]
        public void ShouldNotConvertNegativeValue()
        {
            var radix = 20;
            var negativeValue = -1524;

            var converter = new NumberRadixConverter(radix);

            Assert.Throws<NumberRadixException>(() => converter.Convert(negativeValue));
        }

        [Fact]
        public void ShouldConvertBigNumberToRadix20WithLetters()
        {
            var radix = 20;
            var initialValue = 9999995;

            var convertedValue = new NumberRadixConverter(radix).Convert(initialValue);

            Assert.Equal("329JJF", convertedValue);
        }
    }
}