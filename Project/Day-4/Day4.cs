namespace AdventOfCode2025.Day_4;

public class Day4
{
    //string input = "..@@.@@@@.\r\n@@@.@.@.@@\r\n@@@@@.@.@@\r\n@.@@@@..@.\r\n@@.@@@@.@@\r\n.@@@@@@@.@\r\n.@.@.@.@@@\r\n@.@@@.@@@@\r\n.@@@@@@@@.\r\n@.@.@@@.@.";
    string input = File.ReadAllText("Day-4/input.txt");
    public void Part1()
    {
        var matrix = input.Split("\r\n").Select(line => line.ToCharArray()).ToArray();
        var totalRolls = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == '@' && HasValidNeighborCount(i, j, matrix))
                {
                    totalRolls++;
                }
            }
        }
        Console.WriteLine(totalRolls);
    }

    private bool HasValidNeighborCount(int i, int j, char[][] matrix)
    {
        int startRow = Math.Max(0, i - 1);
        int endRow = Math.Min(matrix.Length - 1, i + 1);
        int startCol = Math.Max(0, j - 1);
        int endCol = Math.Min(matrix[i].Length - 1, j + 1);
        const int maxPaperRolls = 3;
        var counter = 0;
       
        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                if (row == i && col == j)
                {
                    continue;
                }
                if (matrix[row][col] == '@' && ++counter > maxPaperRolls)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Part2()
    {
        var matrix = input.Split("\r\n").Select(line => line.ToCharArray()).ToArray();
        var totalRolls = 0;
        while (true)
        {
            var currentRolls = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '@' && HasValidNeighborCount(i, j, matrix))
                    {
                        currentRolls++;
                        matrix[i][j] = '.';
                    }
                }
            }
            totalRolls += currentRolls;
            if (currentRolls == 0)
            {
                break;
            }
        }
        Console.WriteLine(totalRolls);
    }
}
