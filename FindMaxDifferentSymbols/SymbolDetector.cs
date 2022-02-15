namespace FindMaxDifferentSymbols
{
    public class SymbolDetector
    {
        private readonly string line;

        public SymbolDetector(string line)
        {
            this.line = line ?? throw new ArgumentNullException(nameof(line));
        }

        public int DetectDifferentSymbols()
        {
            char lastCheckedChar = (char)0;
            int differentSymbolCount = 0;
            int maxDifferentSymbolCount = 0;
            foreach(char checkSymbol in line)
            {
                if (checkSymbol == lastCheckedChar)
                {
                    maxDifferentSymbolCount = Math.Max(differentSymbolCount, maxDifferentSymbolCount);
                    differentSymbolCount = 0;
                }
                differentSymbolCount++;
                lastCheckedChar = checkSymbol;
            }
            maxDifferentSymbolCount = Math.Max(differentSymbolCount, maxDifferentSymbolCount);
            return maxDifferentSymbolCount;
        }
    }
}
