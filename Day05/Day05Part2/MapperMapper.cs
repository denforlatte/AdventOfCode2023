namespace Day05Part2;

public static class MapperMapper
{
    public static Mapper FlattenMappers(Mapper mapper1, Mapper mapper2)
    {
        var map1 = mapper1.Map;
        List<Range> newMap = new();

        for (int i = 0; i < map1.Count; i++)
        {
            long consumedMap1 = 0;

            while (map1[i].range - consumedMap1 > 0)
            {
                var sourceStart = map1[i].sourceStart + consumedMap1;
                var destinationStart = map1[i].destinationStart + consumedMap1;
                var map2Range = mapper2.GetRange(destinationStart, map1[i].range - consumedMap1);
                newMap.Add(new Range()
                {
                    sourceStart = sourceStart,
                    destinationStart = map2Range.destinationStart,
                    range = map2Range.range,
                });

                consumedMap1 += map2Range.range;
            }
        }

        return new Mapper(newMap);
    }
}
