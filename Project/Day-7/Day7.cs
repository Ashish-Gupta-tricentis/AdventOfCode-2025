using System.Diagnostics;

namespace AdventOfCode2025.Day_7;

public class Day7
{
     string input = ".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n...............";
     //string input = File.ReadAllText("Day-7/input.txt");
    public void Part1()
    {
        var lines = input.Split(Environment.NewLine);
        var startPoint = lines[0].IndexOf('S');
        var endPoint = startPoint;
        var beams = new HashSet<(int, int)>();
        beams.Add((1, startPoint));
        int totalsplits = 0;
        for (int row = 1; row < lines.Length; row++)
        {
            for (int col = startPoint; col <= endPoint; col++)
            {
                if (!beams.Contains((row - 1, col)))
                    continue;

                if (lines[row][col] == '^')
                {
                    beams.Add((row, col - 1));
                    beams.Add((row, col + 1));
                    startPoint = Math.Min(col - 1, startPoint);
                    endPoint = Math.Max(col + 1, endPoint);
                    totalsplits++;
                }
                else
                {
                    beams.Add((row, col));
                }
            }
        }
        Console.WriteLine(totalsplits);
    }

    public void Part2()
    {
        var stopwatch = Stopwatch.StartNew();
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var beamCounts = new long[lines[0].Length];
        beamCounts[lines[0].IndexOf('S')] = 1;
        var startPoint = lines[0].IndexOf('S');
        var endPoint = startPoint;
        foreach (var line in lines.Skip(1))
        {
            for (int col = startPoint; col <= endPoint; col++)
            {
                if (line[col] == '^' && beamCounts[col] > 0)
                {
                    long currentBeams = beamCounts[col];
                    beamCounts[col - 1] += currentBeams;
                    beamCounts[col + 1] += currentBeams;
                    beamCounts[col] = 0;
                    startPoint = Math.Min(col - 1, startPoint);
                    endPoint = Math.Max(col + 1, endPoint);
                }
            }
        }
        long timelines = beamCounts.Sum();
        Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine(timelines);
    }
}
