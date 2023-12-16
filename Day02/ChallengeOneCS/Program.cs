using ChallengeOneCS;

var data = InputReader.Read();

var processedData = InputProcessor.ProcessAll(data);

var validGames = processedData.Where(GameValidator.Validate).ToList();

var sum = 0;

validGames.ForEach(game => sum += int.Parse(game.Id));

Console.WriteLine(sum);
