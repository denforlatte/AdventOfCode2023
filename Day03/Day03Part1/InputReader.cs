namespace Day03Part1;

public static class InputReader
{
    private const string FilePath = "input.txt";

    public static List<string> Read()
    {
        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
            using var sr = new StreamReader(path);

            List<string> formattedInput = new();

            while (sr.ReadLine() is { } line)
            {
                formattedInput.Add(line);
            }

            return formattedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
