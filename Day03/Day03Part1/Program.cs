using Day03Part1;

var data = InputReader.Read();

var schematic = new Schematic(data);

var numberCoordinates = schematic.GetNumberCoordinates();

List<int> validNumbers = new();
var count = 0;
var sum = 0;
for (int i = 0; i < numberCoordinates.Count; i++)
{
    var coordsToCheck = schematic.GetAdjacentCoordinates(numberCoordinates[i]);
    foreach (var coords in coordsToCheck)
    {
        var cell = schematic.Schemata[coords.y][coords.x];
        if (char.IsDigit(cell)) continue;
        if (cell == '.') continue;

        var value = schematic.GetNumber(numberCoordinates[i]);
        validNumbers.Add(value);
        count++;
        sum += value;
        break;
    }
}

Console.WriteLine(sum);
