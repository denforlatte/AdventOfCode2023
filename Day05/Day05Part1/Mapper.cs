namespace Day05Part1;

public class Mapper
{
    private readonly List<Range> _map = new();

    public Mapper(List<List<long>> data)
    {
        foreach (var line in data)
        {
            _map.Add(new Range()
            {
                destinationStart = line[0],
                sourceStart = line[1],
                range = line[2],
            });

            _map = _map.OrderBy(range => range.sourceStart).ToList();
        }
    }

    public long Map(long sourceId)
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
    public required long destinationStart { get; init; }
    public required long sourceStart { get; init; }
    public required long range { get; init; }

    public long sourceEnd => sourceStart + range - 1;
}
