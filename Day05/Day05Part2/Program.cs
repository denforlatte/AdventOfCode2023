using Day05Part2;

var data = InputReader.Read();

var seedIds = InputProcessor.ProcessSeedIds(data[0]);

var mappingData = InputProcessor.ExtractMappingData(data.Skip(1).ToList());

var mappers = mappingData.Select(x => new Mapper(x)).ToList();

// Flatten maps
while (mappers.Count > 1)
{
    var flattenedMapper = MapperMapper.FlattenMappers(mappers[0], mappers[1]);
    mappers.RemoveAt(0);
    mappers[0] = flattenedMapper;
}

var reversedMap = mappers[0].GetMapByLocationAsc();

long? nearestLocation = null;

long? lowestOverlap = null;
foreach (var range in reversedMap)
{
    if (lowestOverlap != null) break;

    foreach (var seedRange in seedIds)
    {
        if (range.sourceStart <= seedRange.Start + seedRange.Range && seedRange.Start <= range.sourceEnd)
        {
            var newOverlap = Math.Max(range.sourceStart, seedRange.Start);
            lowestOverlap = Math.Max(lowestOverlap ?? 0, newOverlap);
        }
    }
}

Console.WriteLine(mappers[0].GetDestinationId(lowestOverlap ?? 0));

// 692213654 - too high


// Painfully slow
// for (var i = 0; i < seedIds.Count; i++)
// {
//     for (int j = 0; j < seedIds[i].Range; j++)
//     {
//         var seedId = seedIds[i].Start + i;
//         var id = mappers.Aggregate(seedId, (current, mapper) =>
//         {
//             Console.WriteLine($"Mapping progress {(i + 1)}/{seedIds.Count()}: {Math.Round(((j + 1) / (double)seedIds[i].Range * 100), 4)}%");
//             return mapper.GetDestinationId(current);
//         });
//
//         if (nearestLocation == null || id < nearestLocation)
//         {
//             nearestLocation = id;
//         }
//     }
// }

Console.WriteLine(nearestLocation);

// 2687187253 - too high - Location number, not seed number!!!
