namespace Day04Part2;

public  class ScratchCardProcessor
{
    private readonly List<ScratchCard> _scratchCardLibrary;

    public ScratchCardProcessor(IEnumerable<string> data)
    {
        _scratchCardLibrary = ProcessScratchCards(data);
    }

    public List<ScratchCard> ProcessScratchCards(IEnumerable<string> data)
    {
        return data.Select(ProcessScratchCard).ToList();
    }

    private static ScratchCard ProcessScratchCard(string text)
    {
        var card = text.Split(":");
        var id = card.First().Split(" ").Last();
        var numbers = card.Last().Split("|");

        var winningNumbers = numbers.First().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
        var scratchedNumbers = numbers.Last().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

        return new ScratchCard
        {
            Id = int.Parse(id),
            WinningNumbers = winningNumbers,
            ScratchedNumbers = scratchedNumbers,
        };
    }

    public List<ScratchCard> GetScratchCardReward(ScratchCard card)
    {
        var numberOfMatches = card.ScratchedNumbers.Intersect(card.WinningNumbers).Count(); // Could be an issue with duplicates...

        return _scratchCardLibrary.Slice(card.Id, numberOfMatches).ToList();
    }
}
