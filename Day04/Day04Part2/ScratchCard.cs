namespace Day04Part2;

public class ScratchCard
{
    public required int Id { get; init; }
    public required List<int> WinningNumbers { get; init; }
    public required List<int> ScratchedNumbers { get; init; }
}
