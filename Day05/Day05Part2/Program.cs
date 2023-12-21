using Day05Part2;

var data = InputReader.Read();

var seedIds = InputProcessor.ProcessSeedIds(data[0]);

var mappingData = InputProcessor.ExtractMappingData(data.Skip(1).ToList());

var mappers = mappingData.Select(x => new Mapper(x)).ToList();

double? nearestLocation = null;

for (var i = 0; i < seedIds.Count; i++)
{
    var seedId = seedIds[i];
    var id = mappers.Aggregate(seedId, (current, mapper) =>
    {
        Console.WriteLine($"Mapping progress: {Math.Round((decimal)((i + 1) / seedIds.Count * 100), 4)}%");
        return mapper.Map(current);
    });

    if (nearestLocation == null || id < nearestLocation)
    {
        nearestLocation = id;
    }
}

Console.WriteLine(nearestLocation);

// 2687187253 - too high - Location number, not seed number!!!
