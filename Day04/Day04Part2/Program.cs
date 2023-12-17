using Day04Part2;

var data = InputReader.Read();

var scratchCardProcessor = new ScratchCardProcessor(data);

var scratchCardInventory = scratchCardProcessor.ProcessScratchCards(data);

for (int i = 0; i < scratchCardInventory.Count; i++)
{
    var winnings = scratchCardProcessor.GetScratchCardReward(scratchCardInventory[i]);
    scratchCardInventory.AddRange(winnings);
}

Console.WriteLine(scratchCardInventory.Count);

// 25004 - too low
