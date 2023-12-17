namespace Day04Part1;

public static class ScratchCardProcessor
{
    public static List<ScratchCard> ProcessScratchCards(IEnumerable<string> data)
    {
        return data.Select(ProcessScratchCard).ToList();
    }
    public static ScratchCard ProcessScratchCard(string text)
    {
        var numbers = text.Split(":").Last().Split("|");

        var winningNumbers = numbers.First().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var scratchedNumbers = numbers.Last().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

        return new ScratchCard
        {
            WinningNumbers = winningNumbers,
            ScratchedNumbers = scratchedNumbers,
        };
    }

    public static int GetScratchCardScore(ScratchCard card)
    {
        var numberOfMatches = card.ScratchedNumbers.Intersect(card.WinningNumbers).Count(); // Could be an issue with duplicates...

        if (numberOfMatches == 0) return 0;

        return (int)Math.Pow(2, numberOfMatches - 1);
    }
}
