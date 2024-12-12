static async Task<string[]> ReadFileContent()
{
    return await File.ReadAllLinesAsync("C:\\Users\\jeroe\\Documents\\dev\\AdventOfCode2024\\AdventOfCode2024\\Day2\\input\\input.txt");
}

string[] fileContent = await ReadFileContent();
int amountOfSaveReports = 0;
var reports = fileContent.Select(s => s.Split(' ').Select(int.Parse));
foreach(IEnumerable<int> report in reports)
{
    if (IsSave(report.ToList()))
    {
        amountOfSaveReports++;
    }
}

Console.WriteLine("Amount of save reports is: " + amountOfSaveReports);
Console.ReadLine();

static bool IsSave(List<int> lines)
{
    if (lines.Count < 2)
    {
        return true;
    }
    int listOrder = 0;
    for(int i = 1; i < lines.Count; i++)
    {
        int calculation = lines[i] - lines[i-1];
        int check = Math.Sign(calculation);
        if(i != 1)
        {
            if (check != listOrder)
            {
                return false;
            }
        }
        else
        {
            listOrder = check;
        }

        if (check == -1 && (calculation < -3 || calculation > -1))
        {
            return false;
        }
        else if(check == 1 && (calculation > 3 || calculation < 1))
        {
            return false;
        }
    }
    return true;
}
