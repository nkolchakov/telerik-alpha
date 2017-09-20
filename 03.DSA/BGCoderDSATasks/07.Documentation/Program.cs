using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Documentation
{
    class Program
    {
        static int[,] memo = new int[27, 27];

        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine().ToLower());
            int left = 0;
            int right = input.Length - 1;

            int counter = 0;

            int lettersCount = 26;

            while (left < right)
            {
                if (input[left] == input[right])
                {
                    right--;
                    left++;
                    continue;
                }
                if (!char.IsLetter(input[left]))
                {
                    left++;
                }
                else if (!char.IsLetter(input[right]))
                {
                    right--;
                }
                else
                {
                    int first = input[left] - 97;
                    int second = input[right] - 97;

                    if (memo[first, second] == 0)
                    {
                        int maxEl = 0;
                        int minEl = 0;
                        if (first > second)
                        {
                            maxEl = first;
                            minEl = second;
                        }
                        else
                        {
                            maxEl = second;
                            minEl = first;
                        }
                        int firstDiff = maxEl - minEl;
                        int secondDiff = lettersCount - maxEl + minEl;
                        int operations = Math.Min(firstDiff, secondDiff);

                        memo[first, second] = operations;
                        memo[second, first] = operations;
                    }

                    counter += memo[first, second];

                    right--;
                    left++;
                }

            }
            Console.WriteLine(counter);
        }
    }
}
