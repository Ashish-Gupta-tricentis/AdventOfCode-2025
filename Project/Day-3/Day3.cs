using System.Text;

namespace AdventOfCode2025.Day_3;

public class Day3
{
    string input = "811111111111119\r\n234234234234278\r\n818181911112111";
    //string input = File.ReadAllText("Day-3/input.txt");
    public void Part1()
    {
        var lines = input.Split("\r\n");
        var highestPowerInRows = new List<int>();

        foreach (var line in lines)
        {
            int sum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    int currentValue = (line[i] - '0') * 10 + (line[j] - '0');
                    if (sum < currentValue)
                    {
                        sum = currentValue;
                    }
                }

            }
            highestPowerInRows.Add(Convert.ToInt32(sum));
        }
        Console.WriteLine(highestPowerInRows.Sum());
    }

    public void Part2()
    {
        var lines = input.Split("\r\n");
        var size = 12;
        var highestPowerInRows = new List<long>();
        foreach (var line in lines)
        {
            var result =  new StringBuilder();
            GetTheResult(line, size, result);
            highestPowerInRows.Add(Convert.ToInt64(result.ToString()));
        }
        Console.WriteLine(highestPowerInRows.Sum());
    }

    private void GetTheResult(string line, int size, StringBuilder result)
    {
        if (result.Length == size)
        {
            return;
        }
        var windowSize = line.Length - (size - result.Length - 1);
        int maxIndex = FindMaxIndex(line.Substring(0, windowSize));
        result.Append(line[maxIndex]);
        line = line.Remove(0, maxIndex + 1);
        GetTheResult(line, size, result);
    }

    private int FindMaxIndex(string sub)
    {
        char maxChar = sub[0];
        int maxIndex = 0;
        for (int i = 1; i < sub.Length; i++)
        {
            if (sub[i] > maxChar)
            {
                maxChar = sub[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}

