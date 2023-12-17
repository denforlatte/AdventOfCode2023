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
            string colour = splitResults[i+1];
            int amount = short.Parse(splitResults[i]);

            switch (colour)
            {
                case ("red"):
                    if (amount > game.HighestRed) game.HighestRed = amount;
                    break;
                case ("green"):
                    if (amount > game.HighestGreen) game.HighestGreen = amount;
                    break;
                case ("blue"):
                    if (amount > game.HighestBlue) game.HighestBlue = amount;
                    break;
                default:
                    throw new Exception($"Unknown colour: '{colour}'");
            }
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
    public int HighestRed { get; set; } = 0;
    public int HighestGreen { get; set; } = 0;
    public int HighestBlue { get; set; } = 0;
}
