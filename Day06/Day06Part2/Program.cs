using System;
using Day06Part1;

var data = InputReader.Read();

var race = InputProcessor.ParseRaces(data);

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

Console.WriteLine(validCount);
