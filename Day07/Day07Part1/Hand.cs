namespace Day07Part1;

public class Hand
{
    public required string Cards { get; init; }
    public required int Bid { get; init; }

    // Five of a kind - 6
    // Four of a kind - 5
    // Full house - 4
    // Three of a kind - 3
    // Two pair - 2
    // One pair - 1
    // High card - 0
    public int GetHandType()
    {
        Dictionary<char, int> counts = new();

        foreach (var card in Cards)
        {
            counts.TryGetValue(card, out var count);
            counts[card] = count + 1;
        }

        var sortedCards = counts.OrderByDescending(x => x.Value).ToList();

        if (sortedCards[0].Value == 5) return 6;
        if (sortedCards[0].Value == 4) return 5;
        if (sortedCards[0].Value == 3 && sortedCards[1].Value == 2) return 4;
        if (sortedCards[0].Value == 3 && sortedCards[1].Value == 1) return 3;
        if (sortedCards[0].Value == 2 && sortedCards[1].Value == 2) return 2;
        if (sortedCards[0].Value == 2 && sortedCards[1].Value == 1) return 1;
        return 0;
    }

    public static int GetCardValue(char card)
    {
        if (card == 'A') return 14;
        if (card == 'K') return 13;
        if (card == 'Q') return 12;
        if (card == 'J') return 11;
        if (card == 'T') return 10;
        return int.Parse(card.ToString());
    }
}
