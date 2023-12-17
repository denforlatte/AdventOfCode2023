using Day04Part1;

var data = InputReader.Read();

var scratchCards = ScratchCardProcessor.ProcessScratchCards(data);

var sum = 0;

scratchCards.ForEach(card =>
{
    sum += ScratchCardProcessor.GetScratchCardScore(card);
});

Console.WriteLine(sum);
