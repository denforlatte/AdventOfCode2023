namespace Day07Part1;

public static class InputProcessor
{
    public static List<Hand> ProcessHands(List<string> data)
    {
        List<Hand> hands = new();

        foreach (var line in data)
        {
            var hand = line.Split(" ");
            hands.Add(new Hand()
            {
                Cards = hand[0],
                Bid = int.Parse(hand[1]),
            });
        }

        return hands;
    }
}
