namespace Day06Part1;

public static class InputProcessor
{
    public static List<Race> ParseRaces(List<string> data)
    {
        var times = data[0].Split(" ").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var records = data[1].Split(" ").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        List<Race> races = new();

        for (int i = 0; i < times.Length; i++)
        {
            races.Add(new Race()
            {
                TimeLimit = int.Parse(times[i]),
                RecordDistance = int.Parse(records[i]),
            });
        }

        return races;
    }
}
