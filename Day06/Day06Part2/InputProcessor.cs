namespace Day06Part1;

public static class InputProcessor
{
    public static Race ParseRaces(List<string> data)
    {
        var times = data[0].Split(" ").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        var records = data[1].Split(" ").Skip(1).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        List<Race> races = new();

        string timeLimit = "";
        string recordDistance = "";
        for (int i = 0; i < times.Length; i++)
        {
            timeLimit += times[i];
            recordDistance += records[i];
        }

        return new Race()
        {
            TimeLimit = long.Parse(timeLimit),
            RecordDistance = long.Parse(recordDistance),
        };
    }
}
