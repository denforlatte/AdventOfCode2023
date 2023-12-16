namespace ChallengeOneCS;

public static class GameValidator
{
    public static bool Validate(GameTally game)
    {
        foreach (var result in game.Results)
        {
            switch (result.Colour)
            {
                case ("red"):
                    if (result.Amount > 12) return false;
                    break;
                case ("green"):
                    if (result.Amount > 13) return false;
                    break;
                case ("blue"):
                    if (result.Amount > 14) return false;
                    break;
                default:
                    throw new Exception($"Unknown colour '{result.Colour}'");
            }
        }

        return true;
    }
}
