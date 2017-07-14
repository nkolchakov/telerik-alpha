using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.NFactorial
{
    /*
     * Write a method that multiplies a number represented as an array of digits by a given integer number.
     * Write a program to calculate N!.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] res = Factorial(n);
            Console.WriteLine(string.Join("", res));
        }



        private static int[] NumToArr(int num)
        {
            var res = new Stack<int>();
            while (num > 0)
            {
                res.Push(num % 10);
                num /= 10;
            }
            return res.ToArray();
        }


        private static int[] Factorial(int n)
        {
            n = n == 0 ? 1 : n;
            int[] res = NumToArr(n--);

            while (n > 0)
            {
                res = MultiplyBy(res, n--);

            }
            return res;
        }

        private static int[] MultiplyBy(int[] arr, int mlt)
        {
            if (mlt / 10 <= 0)
            {
                return MultiplyBySingleDigit(arr, mlt);
            }

            int ones = mlt % 10;
            int tens = mlt / 10;

            var firstNum = MultiplyBySingleDigit(arr, ones); // need leading zeroes
            var secondNum = MultiplyBySingleDigit(arr, tens); // need trailing zeores

            int leadingZeroes = secondNum.Length - firstNum.Length + 1;

            PutLeadingZeroes(ref firstNum, leadingZeroes);
            PutTrailingZero(ref secondNum);

            var res = Sum(firstNum, secondNum);

            return res;

        }

        private static int[] Sum(int[] first, int[] second)
        {
            int n = first.Length;
            var res = new int[n];

            bool hasRemainder = false;
            for (int i = n - 1; i >= 0; i--)
            {
                int toAdd = first[i] + second[i];
                if (hasRemainder) toAdd++;

                res[i] = toAdd % 10;
                hasRemainder = toAdd >= 10;
            }

            if (hasRemainder)
            {
                var leadingRem = new int[res.Length + 1];
                leadingRem[0] = 1;
                res.CopyTo(leadingRem, 1);
                return leadingRem;
            }

            return res;
        }

        private static void PutTrailingZero(ref int[] secondNum)
        {
            var res = new int[secondNum.Length + 1];
            secondNum.CopyTo(res, 0);
            secondNum = res;
        }

        private static void PutLeadingZeroes(ref int[] arr, int times)
        {
            int[] res = new int[arr.Length + times];
            arr.CopyTo(res, times);
            arr = res;
        }

        private static int[] MultiplyBySingleDigit(int[] arr, int mlt)
        {
            int[] res = new int[arr.Length];
            int remaining = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int toAdd = remaining >= 0 ? (arr[i] * mlt) + remaining : (arr[i] * mlt);
                res[i] = toAdd % 10;
                remaining = toAdd / 10;
            }

            if (remaining > 0)
            {
                var leadingRem = new int[arr.Length + 1];
                leadingRem[0] = remaining;
                res.CopyTo(leadingRem, 1);
                res = leadingRem;
            }

            return res;
        }

    }
}
