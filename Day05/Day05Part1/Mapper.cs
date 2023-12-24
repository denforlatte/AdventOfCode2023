namespace Day05Part1;

public class Mapper
{
    private readonly List<Range> _map = new();

    public List<Range> Map => _map;

    public Mapper(List<Range> map)
    {
        _map = map;
    }

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

    public Range GetRange(long sourceId, long sourceRange)
    {
        foreach (var range in _map)
        {
            if (sourceId > range.sourceEnd) continue;

            if (sourceId < range.sourceStart) break;

            var diff = sourceId - range.sourceStart;

            return new Range()
            {
                sourceStart = range.sourceStart + diff,
                destinationStart = range.destinationStart + diff,
                range = Math.Min(sourceRange, range.range - diff),
            };
        }

        foreach (var range in _map)
        {
            var sourceEnd = sourceId + sourceRange;

            if (sourceId > range.sourceEnd) continue;

            if (sourceEnd >= range.sourceStart)
            {
                return new Range()
                {
                    sourceStart = sourceId,
                    destinationStart = sourceId,
                    range = range.sourceStart - sourceId,
                };
            }
        }

        return new Range()
        {
            sourceStart = sourceId,
            destinationStart = sourceId,
            range = sourceRange,
        };
    }

    public long GetDestinationId(long sourceId)
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
