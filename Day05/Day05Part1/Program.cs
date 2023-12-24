using Day05Part1;

var data = InputReader.Read();

var seedIds = InputProcessor.ProcessSeedIds(data[0]);

var mappingData = InputProcessor.ExtractMappingData(data.Skip(1).ToList());

var mappers = mappingData.Select(x => new Mapper(x)).ToList();

long? nearestLocation = null;

foreach (var seedId in seedIds)
{
    var id = mappers.Aggregate(seedId, (current, mapper) => mapper.Map(current));

    if (nearestLocation == null || id < nearestLocation)
    {
        nearestLocation = id;
    }
}

Console.WriteLine(nearestLocation);
Console.WriteLine(nearestLocation == 51752125);

// 2687187253 - too high - Location number, not seed number!!!
