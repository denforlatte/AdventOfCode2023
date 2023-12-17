using ChallengeOneCS;

var data = InputReader.Read();

var processedData = InputProcessor.ProcessAll(data);

var sum = 0;

processedData.ForEach(game => sum += game.HighestRed * game.HighestGreen * game.HighestBlue);

Console.WriteLine(sum);
