using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static char[,] maze =
    {
        {' ', ' ', ' '},
        {' ', 'x', ' '},
        {' ', ' ', 'e'}
    };

    static List<char> path = new List<char>();

    public static void Main()
    {
        FindExit(0, 0, ' ');
    }

    static void FindExit(int row, int col, char direction)
    {
        if ((col < 0) || (row < 0) || (col >= maze.GetLength(1))
            || (row >= maze.GetLength(0)))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }

        // Add only if not visited or it is the exit
        if (direction != ' ' && maze[row, col] == ' ')
        {
            path.Add(direction);
        }

        // Check if we have found the exit
        if (maze[row, col] == 'e')
        {
            Console.WriteLine(string.Join(",", path) + "," + direction);
            Console.WriteLine("Found the exit!");
            //return;
        }

        if (maze[row, col] != ' ')
        {
            // The current cell is not free -> can't find a path
            return;
        }

        // Temporary mark the current cell as visited
        maze[row, col] = 's';

        // Invoke recursion to explore all possible directions
        FindExit(row - 1, col, 'U'); // up
        FindExit(row, col + 1, 'R'); // right
        FindExit(row + 1, col, 'D'); // down
        FindExit(row, col - 1, 'L'); // left


        // Mark back the current cell as free
        maze[row, col] = ' ';

        if (path.Any())
        {
            path.RemoveAt(path.Count - 1);
        }

    }
}