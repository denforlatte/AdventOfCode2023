namespace Day03Part1;

public class Schematic
{
    public char[][] Schemata { get; init; }
    private int _yLength;
    private int _xLength;

    public Schematic(List<string> data)
    {
        _yLength = data.Count;
        _xLength = data[0].Length;
        Schemata = new char[_yLength][];

        for (int i = 0; i < data.Count; i++)
        {
            Schemata[i] = data[i].ToCharArray();
        }
    }

    public int GetNumber(((int x, int y) start, int length) numberCoords)
    {
        string number = "";

        for (int i = 0; i < numberCoords.length; i++)
        {
            number += Schemata[numberCoords.start.y][numberCoords.start.x + i];
        }

        return int.Parse(number);
    }

    public List<((int x, int y) start, int length)> GetNumberCoordinates()
    {
        List<((int x, int y) start, int length)> numbers = new();

        for (int y = 0; y < Schemata.Length; y++)
        {
            bool inNumber = false;
            (int x, int y) start = new();
            int length = 0;
            for (int x = 0; x < Schemata[y].Length; x++)
            {
                if (char.IsDigit(Schemata[y][x]))
                {
                    if (!inNumber)
                    {
                        inNumber = true;
                        start = (x, y);
                        length = 1;
                    }
                    else
                    {
                        length++;
                    }
                }
                else
                {
                    if (inNumber)
                    {
                        inNumber = false;
                        numbers.Add((start, length));
                    }
                }
            }
            if (inNumber)
            {
                numbers.Add((start, length));
            }
        }

        return numbers;
    }

    public List<(int x, int y)> GetAdjacentCoordinates(((int x, int y) start, int length) number)
    {
        List<(int x, int y)> range = new(){number.start};

        for (int i = 1; i < number.length; i++)
        {
            range.Add((number.start.x + i, number.start.y));
        }

        return GetAdjacentCoordinates(range);
    }

    public List<(int x, int y)> GetAdjacentCoordinates(List<(int x, int y)> range)
    {
        List<(int x, int y)> coords = new();
        range.ForEach(cell => coords.AddRange(GetAdjacentCoordinates(cell.x, cell.y)));

        // TODO optimise

        return coords;
    }

    public List<(int x, int y)> GetAdjacentCoordinates(int x, int y)
    {
        var coords = new List<(int x, int y)>()
        {
            (x - 1, y),
            (x - 1, y - 1),
            (x - 1, y + 1),
            (x + 1, y),
            (x + 1, y - 1),
            (x + 1, y + 1),
            (x, y - 1),
            (x, y + 1),
        };

        for (int i = coords.Count - 1; i >= 0; i--)
        {
            if (coords[i].x < 0 || coords[i].y < 0)
            {
                coords.RemoveAt(i);
            }
            else if (coords[i].x >= _xLength || coords[i].y >= _yLength)
            {
                coords.RemoveAt(i);
            }
        }

        return coords;
    }

    // private bool IsSymbol
}
