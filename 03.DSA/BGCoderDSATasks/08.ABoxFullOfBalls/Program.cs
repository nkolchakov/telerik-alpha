using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ABoxFullOfBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int a = ab[0];
            int b = ab[1];

            var isWins = new bool[b + 1];
            isWins[0] = false;

            for (int i = 1; i <= b; i++)
            {
                foreach (int m in moves)
                {
                    if (m > i)
                    {
                        continue;
                    }
                    if (!isWins[i - m])
                    {
                        isWins[i] = true;
                    }
                }
            }

            int total = 0;
            for (int i = a; i <= b; i++)
            {
                if (isWins[i])
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }

        //static bool IsWinning(int[] moves, int balls, bool[] memo)
        //{
        //    if (balls <= 0)
        //    {
        //        return false;
        //    }

        //    foreach (int move in moves)
        //    {
        //        if (balls - move < 0)
        //        {
        //            continue;
        //        }
        //        if (memo[balls - move])
        //        {
        //            return true;
        //        }
        //        else if (!IsWinning(moves, balls - move, memo)) // next player's move if its losing, we win
        //        {
        //            memo[balls] = true;
        //            return true;
        //        }
        //    }
        //    return false;

        //}
    }
}
