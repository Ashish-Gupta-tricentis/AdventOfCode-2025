using System.Diagnostics;
using System.Text;
namespace AdventOfCode2025.Day_6;

public class Day6
{

    public void Part1()
    {
        //string input = "123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +";
        string input = File.ReadAllText("Day-6/input.txt");
        var lines = input.Split(Environment.NewLine).Select(line => line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();
        long total = 0;
        for (int col = 0; col < lines[0].Length; col++)
        {
            var operatorSymbol = lines[^1][col];
            long colValueTotal;
            if (operatorSymbol == "+")
            {
                colValueTotal = 0;
                for (int row = 0; row < lines.Length - 1; row++)
                {
                    colValueTotal += long.Parse(lines[row][col]);
                }
            }
            else
            {
                colValueTotal = 1;
                for (int row = 0; row < lines.Length - 1; row++)
                {
                    colValueTotal *= long.Parse(lines[row][col]);
                }
            }
            total += colValueTotal;
        }
        Console.WriteLine(total);
    }
    public void Part2()
    {
        var stopwatch = Stopwatch.StartNew();
        string input = File.ReadAllText("Day-6/input.txt");
        var lines = input.Split(Environment.NewLine);
        long total = 0;
        var numberBuilder = new StringBuilder();
        int lastRow = lines.Length - 1;
        List<long> numbersInColumn = new List<long>();
        for (int col = lines[0].Length - 1; col >= 0; col--)
        {
            char operatorSymbol = lines[lastRow][col];
            numberBuilder.Clear();
            for (int row = 0; row < lastRow; row++)
            {
                char c = lines[row][col];
                if (c != ' ')
                {
                    numberBuilder.Append(c);
                }
            }
            if (numberBuilder.Length > 0)
            {
                numbersInColumn.Add(long.Parse(numberBuilder.ToString()));
            }
            if (operatorSymbol != ' ')
            {
                long colTotal = 0;
                if (operatorSymbol == '+')
                {
                    foreach (var num in numbersInColumn)
                    {
                        colTotal += num;
                    }
                }
                else
                {
                    colTotal = 1;
                    foreach (var num in numbersInColumn)
                    {
                        colTotal *= num;
                    }
                }
                total += colTotal;

                numbersInColumn.Clear();
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine(total);
    }
}
