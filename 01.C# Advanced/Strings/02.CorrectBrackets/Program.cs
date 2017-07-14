using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isCorrect = CheckCorrectBrackets(input); // or use Stack to put and take out brackets
            Console.WriteLine(isCorrect ? "Correct" : "Incorrect");
        }

        private static bool CheckCorrectBrackets(string text)
        {
            int count = 0;
            bool firstSymbol = true;
            foreach (var ch in text)
            {
                if (firstSymbol && ch == ')')
                {
                    return false;
                }
                else firstSymbol = false;
                if (ch == '(')
                {
                    count++;
                }
                else if (ch == ')')
                {
                    count--;
                }
            }
            return count == 0;
        }
    }
}
