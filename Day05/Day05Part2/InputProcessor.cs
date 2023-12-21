namespace Day05Part2;

public static class InputProcessor
{
    public static List<double> ProcessSeedIds(string data)
    {
        var numbers = data.Split(" ").Skip(1).Select(double.Parse).ToList();
        List<double> seedIds = new();

        var totalNumberOfSeeds = 0d;

        for (int i = 0; i < numbers.Count; i += 2)
        {
            totalNumberOfSeeds += numbers[i + 1];
        }
        Console.WriteLine($"Total number of seeds: {totalNumberOfSeeds}");

        var count = 0d;
        for (int i = 0; i < numbers.Count; i += 2)
        {
            var start = numbers[i];
            var range = numbers[i + 1];


            for (int j = 0; j < range; j++)
            {
                count++;
                Console.WriteLine($"Progress: {Math.Round((decimal)(count / totalNumberOfSeeds) * 100, 4)}%");
                seedIds.Add(start + j);
            }
        }

        return seedIds;
    }

    public static List<List<List<double>>> ExtractMappingData(List<string> data)
    {
        List<List<List<double>>> maps = new() {new List<List<double>>()};
        int counter = 0;

        while (string.IsNullOrWhiteSpace(data[0])) data.RemoveAt(0);

        foreach (var line in data.Where(line => !line.Contains(":")))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                counter++;
                maps.Add(new List<List<double>>());
                continue;
            }

            maps[counter].Add(line.Split(" ").Select(double.Parse).ToList());
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
