using System.Text;

namespace ConvertNumberToXNotation
{
    public class NumberRadixConverter
    {
        private const int MinRadix = 2;
        private const int MaxRadix = 20;

        private static readonly char[] RadixSymbols = "0123456789ABCDEFGHIJ".ToCharArray();

        private readonly int radix;

        public NumberRadixConverter(int radix)
        {
            ValidateRadix(radix);
            this.radix = radix;
        }

        private void ValidateRadix(int radix)
        {
            if (radix < MinRadix || radix > MaxRadix)
                throw new NumberRadixException($"The radix must be in range from {MinRadix} to {MaxRadix}.");
        }

        public string Convert(int number)
        {
            ValidateNumber(number);
            StringBuilder result = new StringBuilder();

            int residue = number;

            while (residue >= radix)
            {
                result.Insert(0, GetSymbol(residue % radix));
                residue /= radix;
            }
            result.Insert(0, GetSymbol(residue));

            return result.ToString();
        }

        private static void ValidateNumber(int number)
        {
            if (number <= 0)
                throw new NumberRadixException("Number must be more that zero.");
        }

        private char GetSymbol(int residueFromRadixDivision)
        {
            return RadixSymbols[residueFromRadixDivision];
        }
    }
}
