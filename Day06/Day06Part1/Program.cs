using System;
using Day06Part1;

var data = InputReader.Read();

var races = InputProcessor.ParseRaces(data);

var total = 0;
foreach (var race in races)
{
    var validCount = 0;

    for (int i = 0; i <= race.TimeLimit; i++)
    {
        var speed = i;
        var distance = i * (race.TimeLimit - i);

        if (distance > race.RecordDistance)
        {
            validCount++;
        }
    }

    if (total == 0)
    {
        total = validCount;
    }
    else
    {
        total *= validCount;
    }
}

Console.WriteLine(total);
