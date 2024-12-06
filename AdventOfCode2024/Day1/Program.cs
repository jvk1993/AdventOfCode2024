string[] fileContent = await ReadFileContent();

List<int> left = [];
List<int> right = [];

foreach (var line in fileContent)
{
    string[] numbers = line.Split("   ");
    left.Add(int.Parse(numbers.First()));
    right.Add(int.Parse(numbers.Last()));
}

left.Sort();
right.Sort();

Func<int, int, int> CalculatedDifference = (firstNumber, secondNumber) =>
{
    if (firstNumber < secondNumber)
    {
        return secondNumber - firstNumber;
    }
    return firstNumber - secondNumber;
};

var zippedList = left.Zip(right, (first, second) => CalculatedDifference(first, second));
Console.WriteLine(zippedList.Sum());
Console.ReadLine();

static async Task<string[]> ReadFileContent()
{
    return await File.ReadAllLinesAsync("C:\\Users\\jeroe\\Documents\\dev\\AdventOfCode2024\\AdventOfCode2024\\Day1\\input\\Day1Input.txt");
}