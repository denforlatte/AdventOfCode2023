using Day05Part1;

var data = InputReader.Read();

var seedIds = InputProcessor.ProcessSeedIds(data[0]);

var mappingData = InputProcessor.ExtractMappingData(data.Skip(1).ToList());

var mappers = mappingData.Select(x => new Mapper(x)).ToList();

while (mappers.Count > 1)
{
    var flattenedMapper = MapperMapper.FlattenMappers(mappers[0], mappers[1]);
    mappers.RemoveAt(0);
    mappers[0] = flattenedMapper;
}

long? nearestSeedId = null;
long? nearestLocation = null;

foreach (var seedId in seedIds)
{
    var id = mappers.Aggregate(seedId, (current, mapper) => mapper.GetDestinationId(current));

    if (nearestLocation == null || id < nearestLocation)
    {
        nearestLocation = id;
        nearestSeedId = seedId;
    }
}

Console.WriteLine(nearestSeedId);
Console.WriteLine(nearestLocation);
