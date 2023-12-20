namespace Day05Part1;

public class Mapper
{
    private readonly List<Range> _map = new();

    public Mapper(IEnumerable<string> data)
    {
        foreach (var datum in data)
        {
            var split = datum.Split(" ");

            _map.Add(new Range()
            {
                destinationStart = double.Parse(split[0]),
                sourceStart = double.Parse(split[1]),
                range = double.Parse(split[2]),
            });

            _map = _map.OrderBy(range => range.sourceStart).ToList();
        }
    }

    public double Map(double sourceId)
    {
        foreach (var range in _map)
        {
            if (sourceId > range.sourceEnd) continue;

            if (sourceId < range.sourceStart) break;

            var diff = sourceId - range.sourceStart;
            return range.destinationStart + diff;
        }

        return sourceId;
    }
}

public class Range
{
    public required double destinationStart { get; init; }
    public required double sourceStart { get; init; }
    public required double range { get; init; }

    public double sourceEnd => sourceStart + range - 1;
}
