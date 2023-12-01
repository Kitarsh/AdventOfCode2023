using System.Text.RegularExpressions;

namespace Domain;

public class CalibrationLine
{
    private string input;

    public CalibrationLine(string input)
    {
        this.input = input;
    }

    public int GetNumber()
    {
        var regex = new Regex("[1-9]");
        var result = regex.Matches(this.input);

        var firstChar = result.First().Value.ToCharArray().First();
        var lastChar = result.Last().Value.ToCharArray().Last();

        var numberStr = new string((new char[] { firstChar, lastChar }));
        return Int32.Parse(numberStr);
    }
}