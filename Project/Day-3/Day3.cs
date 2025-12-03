using System.Text;
using System.Xml.Linq;

namespace AdventOfCode2025.Day_3;

public class Day3
{
    string input = "987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111";
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

    //public void Part2()
    //{
    //    var lines = input.Split("\r\n");
    //    var highestPowerInRows = new List<long>();
    //    var queueSize = 12;
    //    foreach (var line in lines)
    //    {
    //        int i = 0;
    //        int j = 12;
    //        var sb = new StringBuilder();
    //        for (i = 0; i < line.Length; i++)
    //        {

    //        }
    //        highestPowerInRows.Add(Convert.ToInt64(sb.ToString()));
    //    }
    //    Console.WriteLine(highestPowerInRows.Sum());
    //}

}

