namespace ChallengeOneCS;

public static class InputProcessor
{
    public static List<GameTally> ProcessAll(List<string> data)
    {
        return data.Select(Process).ToList();
    }

    public static GameTally Process(string gameResults)
    {
        gameResults = gameResults.Replace(":", "");
        gameResults = gameResults.Replace(";", "");
        gameResults = gameResults.Replace(",", "");

        var splitResults = gameResults.Split(" ");

        var game = new GameTally(splitResults[1]);

        for (int i = 2; i < splitResults.Length; i += 2)
        {
            game.Results.Add((splitResults[i+1], short.Parse(splitResults[i])));
        }

        return game;
    }
}

public class GameTally
{
    public GameTally(string id)
    {
        Id = id;
    }

    public string Id { get; init; }
    public List<(string Colour, int Amount)> Results { get; } = new();
}
