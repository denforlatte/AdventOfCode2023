namespace Day05Part2;

public class Range
{
    public required long destinationStart { get; init; }
    public required long sourceStart { get; init; }
    public required long range { get; init; }

    public long sourceEnd => sourceStart + range - 1;
}
