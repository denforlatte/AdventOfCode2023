using Day05Part1;

var seedData = InputReader.Read("seeds");
var seedToSoilData = InputReader.Read("seed-to-soil");
var soilToFertiliserData = InputReader.Read("soil-to-fertiliser");
var fertiliserToWaterData = InputReader.Read("fertiliser-to-water");
var waterToLightData = InputReader.Read("water-to-light");
var lightToTemperatureData = InputReader.Read("light-to-temperature");
var temperatureToHumidityData = InputReader.Read("temperature-to-humidity");
var humidityToLocationData = InputReader.Read("humidity-to-location");

var seedToSoilMapper = new Mapper(seedToSoilData);
var soilToFertiliserMapper = new Mapper(soilToFertiliserData);
var fertiliserToWaterMapper = new Mapper(fertiliserToWaterData);
var waterToLightMapper = new Mapper(waterToLightData);
var lightToTemperatureMapper = new Mapper(lightToTemperatureData);
var temperatureToHumidityMapper = new Mapper(temperatureToHumidityData);
var humidityToLocationMapper = new Mapper(humidityToLocationData);

var seedIds = seedData[0].Split(" ").Select(double.Parse).ToList();

double? nearestLocation = null;
// double? nearestLocationSeedId = null;

foreach (var seedId in seedIds)
{
    var soilId = seedToSoilMapper.Map(seedId);
    var fertiliserId = soilToFertiliserMapper.Map(soilId);
    var waterId = fertiliserToWaterMapper.Map(fertiliserId);
    var lightId = waterToLightMapper.Map(waterId);
    var temperatureId = lightToTemperatureMapper.Map(lightId);
    var humidityId = temperatureToHumidityMapper.Map(temperatureId);
    var locationId = humidityToLocationMapper.Map(humidityId);

    if (nearestLocation == null || locationId < nearestLocation)
    {
        nearestLocation = locationId;
        // nearestLocationSeedId = seedId;
    }
}

Console.WriteLine(nearestLocation);

// 2687187253 - too high - Location number, not seed number!!!
