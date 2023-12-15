using ChallengeTwoCS;

var data = InputReader.Read();

data = data.Select(s => string.Concat(Utilities.GetFirstDigit(s), Utilities.GetLastDigit(s))).ToList();

var numbers = data.Select(short.Parse).ToList();

var sum = 0;

numbers.ForEach(number => sum += number);

Console.WriteLine(sum);
