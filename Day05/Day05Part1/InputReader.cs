namespace Day05Part1;

public static class InputReader
{
    public static List<string> Read() => Read("input");
    public static List<string> Read(string file)
    {
        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{file}.txt");
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
