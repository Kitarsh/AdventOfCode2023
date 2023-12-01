using System.Text.RegularExpressions;

namespace Domain;

public class CalibrationLine
{
    private const string PatternWithLetters = "(?=([1-9]|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)))";
    private const string PatternWithoutLetters = "[1-9]";
    private string input;

    public CalibrationLine(string input)
    {
        this.input = input;
    }

    public int GetNumber()
    {
        var regex = new Regex(PatternWithLetters);
        var result = regex.Matches(this.input);

        char firstChar = GetFirstNumber(result);
        char lastChar = GetLastNumber(result);
        Console.WriteLine($"{firstChar}{lastChar} {this.input}");
        var numberStr = new string((new char[] { firstChar, lastChar }));
        return Int32.Parse(numberStr);
    }

    private static char GetLastNumber(MatchCollection result)
    {
        var value = result.Last().Groups[1].Value;
        return TransformToNumber(value);
    }

    private static char GetFirstNumber(MatchCollection result)
    {
        var value = result.First().Groups[1].Value;
        return TransformToNumber(value);
    }

    private static char TransformToNumber(string value)
    {
        if (value.Length == 1) return value[0];

        switch (value)
        {
            case "one": return '1';
            case "two": return '2';
            case "three": return '3';
            case "four": return '4';
            case "five": return '5';
            case "six": return '6';
            case "seven": return '7';
            case "eight": return '8';
            case "nine": return '9';
        }
        throw new ApplicationException("CannotTransformNumber");
    }
}