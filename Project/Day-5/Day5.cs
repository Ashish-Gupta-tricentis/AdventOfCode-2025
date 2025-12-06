using System.Diagnostics;

namespace AdventOfCode2025.Day_5;

public class Day5
{
    //string input = "3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32";
    string input = File.ReadAllText("Day-5/input.txt");
    public void Part1()
    {
        var sections = input.Split(Environment.NewLine + Environment.NewLine).ToArray();

        var ranges = sections[0].Split(Environment.NewLine).Select(line =>
        {
            var parts = line.Split('-');
            return (Start: long.Parse(parts[0]), End: long.Parse(parts[1]));
        }).OrderBy(r => r.Start).ToList();
        var numbers = sections[1].Split("\r\n").Select(long.Parse).ToList();
        long count = 0;
        foreach (var number in numbers)
        {
            foreach (var range in ranges)
            {
                if (number >= range.Start && number <= range.End)
                {
                    count++;
                    break;
                }
            }
        }
        Console.WriteLine(count);
    }


    public void Part2()
    {
        var stopwatch = Stopwatch.StartNew();
        var sections = input.Split(Environment.NewLine + Environment.NewLine).ToArray();
        var ranges = sections[0].Split(Environment.NewLine).Select(line =>
        {
            var parts = line.Split('-');
            return (start: long.Parse(parts[0]), end: long.Parse(parts[1]));
        }).OrderBy(r => r.start).ToList();
        var master = new List<(long start, long end)>();
        master.Add(ranges[0]);
        foreach (var range in ranges.Skip(1))
        {
            var last = master[^1];
            if (range.start <= last.end)
            {
                master[^1] = (last.start, Math.Max(last.end, range.end));
            }
            else
            {
                master.Add(range);
            }
        }

        long totalFreshIds = master.Sum(r => r.end - r.start + 1);
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine(totalFreshIds);
    }
}
