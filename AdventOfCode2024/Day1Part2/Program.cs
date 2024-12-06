string[] fileContent = await ReadFileContent();

List<int> left = [];
List<int> right = [];

foreach (var line in fileContent)
{
    string[] numbers = line.Split("   ");
    left.Add(int.Parse(numbers.First()));
    right.Add(int.Parse(numbers.Last()));
}

var groupedRight = right.GroupBy(row => row).ToDictionary(row => row.Key, row => row.Count());
int similarity = 0;
foreach(int item in left)
{
    groupedRight.TryGetValue(item, out int count);
    if(count > 0)
    {
        similarity += item * count;
    }
}

Console.WriteLine(similarity);
Console.ReadLine();

static async Task<string[]> ReadFileContent()
{
    return await File.ReadAllLinesAsync("C:\\Users\\jeroe\\Documents\\dev\\AdventOfCode2024\\AdventOfCode2024\\Day1\\input\\Day1Input.txt");
}