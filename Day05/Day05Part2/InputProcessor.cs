namespace Day05Part2;

public static class InputProcessor
{
    public static List<(long Start, long Range)> ProcessSeedIds(string data)
    {
        var numbers = data.Split(" ").Skip(1).Select(long.Parse).ToList();
        List<(long Start, long Range)> seeds = new();

        for (int i = 0; i < numbers.Count(); i += 2)
        {
            seeds.Add((numbers[i], numbers[i + 1]));
        }

        return seeds;
    }

    public static List<List<List<long>>> ExtractMappingData(List<string> data)
    {
        List<List<List<long>>> maps = new() {new List<List<long>>()};
        int counter = 0;

        while (string.IsNullOrWhiteSpace(data[0])) data.RemoveAt(0);

        foreach (var line in data.Where(line => !line.Contains(":")))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                counter++;
                maps.Add(new List<List<long>>());
                continue;
            }

            maps[counter].Add(line.Split(" ").Select(long.Parse).ToList());
        }

        // Remove blanks caused by the end of the line
        for (int i = maps.Count - 1; i >= 0; i--)
        {
            if (maps[i].Count == 0)
            {
                maps.RemoveAt(i);
            }
        }

        return maps;
    }
}
