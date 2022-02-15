Console.WriteLine("Enter a string:");
var str = Console.ReadLine();
if (string.IsNullOrEmpty(str))
{
    Console.WriteLine("Provided string is empty.");
    return;
}

var differentSymbolCount = new FindMaxDifferentSymbols.SymbolDetector(str).DetectDifferentSymbols();
Console.WriteLine($"Maximum number of unequal consecutive characters in a string: {differentSymbolCount}");
