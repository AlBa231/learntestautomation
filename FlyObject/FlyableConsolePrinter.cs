using System.Globalization;
using FlyObject.Lib.FlyablePrinter;

namespace FlyObject
{
    internal class FlyableConsolePrinter: IFlyablePrinter
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public char ReadChar()
        {
            return Console.ReadKey().KeyChar;
        }

        public int ReadNumber()
        {
            return int.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        }
    }
}
