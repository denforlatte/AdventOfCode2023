using Day03Part2;

var data = InputReader.Read();

var schematic = new Schematic(data);

var sum = 0;
var count = 0;

for (int y = 0; y < schematic.YLength; y++)
{
    for (int x = 0; x < schematic.XLength; x++)
    {
        if (schematic.Schemata[y][x] == '*')
        {
            var coords = schematic.GetAdjacentCoordinates(x, y);
            var numbers = new Dictionary<string, int>();

            foreach (var coord in coords)
            {
                if (Char.IsDigit(schematic.Schemata[coord.y][coord.x]))
                {
                    var startingX = coord.x;
                    var number = schematic.Schemata[coord.y][coord.x].ToString();
                    for (int i = 1; coord.x - i >= 0 && Char.IsDigit(schematic.Schemata[coord.y][coord.x - i]); i++)
                    {
                        number = schematic.Schemata[coord.y][coord.x - i] + number;
                        startingX--;
                    }
                    for (int i = 1; coord.x + i < schematic.XLength && Char.IsDigit(schematic.Schemata[coord.y][coord.x + i]); i++)
                    {
                        number += schematic.Schemata[coord.y][coord.x + i];
                    }

                    numbers.TryAdd($"{startingX}-{coord.y}", int.Parse(number));
                }
            }

            if (numbers.Count < 2) continue;

            if (numbers.Count > 2)
            {
                throw new Exception("Too many numbers! :@");
            }
            
            var gearRatio = numbers.Values.First() * numbers.Values.Last();
            sum += gearRatio;
            count++;
        }
    }
}

Console.WriteLine(sum);
Console.WriteLine(count);

// 103475687 - too high
// 92849478 - wrong
// 88373022 - too low
// 75201781 -
