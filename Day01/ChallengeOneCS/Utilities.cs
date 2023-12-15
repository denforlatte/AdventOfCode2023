namespace ChallengeOneCS;

public static class Utilities
{
    public static char GetFirstDigit(string str)
    {
        foreach (var c in str)
        {
            if (c is >= '0' and <= '9') return c;
        }

        throw new Exception($"No digits in '{str}'");
    }
}
