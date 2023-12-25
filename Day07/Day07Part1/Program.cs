using Day07Part1;

var data = InputReader.Read();

var hands = InputProcessor.ProcessHands(data);

hands[0].GetHandType();

// Sort low to high rank
hands.Sort((hand1, hand2) =>
{
    if (hand1.GetHandType() != hand2.GetHandType())
    {
        return hand1.GetHandType() - hand2.GetHandType();
    }

    for (int i = 0; i < 5; i++)
    {
        var card1 = Hand.GetCardValue(hand1.Cards[i]);
        var card2 = Hand.GetCardValue(hand2.Cards[i]);

        if (card1 != card2)
        {
            return card1 - card2;
        }
    }

    return 0;
});

var total = 0;
for (int i = 0; i < hands.Count; i++)
{
    total += hands[i].Bid * (i + 1);
}

Console.WriteLine(total);
