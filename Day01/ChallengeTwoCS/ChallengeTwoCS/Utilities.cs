namespace ChallengeTwoCS;

public static class Utilities
{
    public static char GetFirstDigit(string str)
    {
        for (int i = 1; i <= str.Length; i++)
        {
            var parsedStr = FindAndReplace(str[..i]);

            foreach (var c in parsedStr)
            {
                if (c is >= '1' and <= '9') return c;
            }
        }

        throw new Exception($"No digits in '{str}'");
    }

    public static char GetLastDigit(string str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
        {
            var parsedStr = FindAndReplace(str[i..]);

            foreach (var c in parsedStr)
            {
                if (c is >= '0' and <= '9') return c;
            }
        }

        throw new Exception($"No digits in '{str}'");
    }

    public static string FindAndReplace(string str)
    {
        str = str.Replace("zero", "0");
        str = str.Replace("one", "1");
        str = str.Replace("two", "2");
        str = str.Replace("three", "3");
        str = str.Replace("four", "4");
        str = str.Replace("five", "5");
        str = str.Replace("six", "6");
        str = str.Replace("seven", "7");
        str = str.Replace("eight", "8");
        str = str.Replace("nine", "9");

        return str;
    }
}
