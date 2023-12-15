using ChallengeOneCS;

var data = InputReader.Read();

data = data.Select(s => string.Concat(Utilities.GetFirstDigit(s), Utilities.GetFirstDigit(new string(s.ToCharArray().Reverse().ToArray())))).ToList();

var numbers = data.Select(short.Parse).ToList();

var sum = 0;

numbers.ForEach(number => sum += number);

Console.WriteLine(sum);
