using ConvertNumberToXNotation;

var number = ReadNumberWithMessage("Enter a number to convert:");
var radix = ReadNumberWithMessage("Enter a Radix to convert number to:");

var convertedNumber = new NumberRadixConverter(radix).Convert(number);
Console.WriteLine($" {number} in {radix} positional notation is - " + convertedNumber);

int ReadNumberWithMessage(string message)
{
    Console.WriteLine(message);
    var strNumber = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(strNumber))
        throw new NumberRadixException($"{strNumber} is not valid number");
    return int.Parse(strNumber);
}