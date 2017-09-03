using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Vegan
{
    class Food
    {
        public Food(string name, int w, int p)
        {
            this.Name = name;
            this.Weight = w;
            this.ProteinPerGram = p;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int ProteinPerGram { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int max = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            var foods = new List<Food>();
            for (int i = 0; i < lines; i++)
            {
                var parts = Console.ReadLine().Split(' ');
                string name = parts[0];
                int weight = int.Parse(parts[1]);
                int protein = int.Parse(parts[2]);

                Food food = new Food(name, weight, protein);
                foods.Add(food);
            }

            var dp = bottomUpDP(foods, max);
            var res = GetElements(dp, foods);

            Console.WriteLine(dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1]);
            Console.WriteLine(string.Join("\n", res));

            // no idea how -- thanks to https://www.youtube.com/watch?v=8LusJS5-AGo&t=638s
        }

        public static HashSet<Food> GetElements(int[,] dp, List<Food> foods)
        {
            var res = new HashSet<Food>();

            for (int col = dp.GetLength(1) - 1; col > 0; col--)
            {
                for (int rol = dp.GetLength(0) - 1; rol > 0; rol--)
                {

                    if (dp[rol, col] == dp[rol - 1, col])
                    {
                        continue;
                    }
                    else if (dp[rol, col] == 0)
                    {
                        return res;
                    }
                    else
                    {
                        res.Add(foods[rol - 1]);
                        col -= foods[rol - 1].Weight;
                    }
                }
            }

            return res;
        }

        public static int[,] bottomUpDP(List<Food> foods, int W)
        {
            int[,] K = new int[foods.Count + 1, W + 1];
            for (int i = 0; i <= foods.Count; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        K[i, j] = 0;
                        continue;
                    }
                    if (j - foods[i - 1].Weight >= 0)
                    {
                        K[i, j] = Math.Max(K[i - 1, j], K[i - 1, j - foods[i - 1].Weight] + foods[i - 1].ProteinPerGram);
                    }
                    else
                    {
                        K[i, j] = K[i - 1, j];
                    }
                }
            }
            return K;
        }

    }
}
