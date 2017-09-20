using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.PlayerRanking
{
    public class Player : IComparable<Player>
    {
        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public int CompareTo(Player other)
        {
            int nameCompareResult = this.Name.CompareTo(other.Name);
            if (nameCompareResult != 0)
            {
                return nameCompareResult;
            }

            int ageCompareResult = other.Age.CompareTo(this.Age);

            if (ageCompareResult != 0)
            {
                return ageCompareResult;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            BigList<Player> rank = new BigList<Player>();
            var playersByType = new Dictionary<string, OrderedSet<Player>>();

            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                var parts = line.Split(' ');
                string command = parts[0];

                switch (command)
                {
                    case "add":
                        string name = parts[1];
                        string type = parts[2];
                        int age = int.Parse(parts[3]);
                        int position = int.Parse(parts[4]);

                        Player newPlayer = new Player(name, type, age, position);
                        if (!playersByType.ContainsKey(type))
                        {
                            playersByType[type] = new OrderedSet<Player>();
                        }
                        playersByType[type].Add(newPlayer);

                        AddPlayer(newPlayer, rank);
                        break;
                    case "find":
                        type = parts[1];

                        FindPlayerByType(type, playersByType);
                        break;
                    case "ranklist":
                        int from = int.Parse(parts[1]);
                        int to = int.Parse(parts[2]);

                        Ranklist(from, to, rank);
                        break;
                    default:
                        break;
                }
            }

        }

        static void FindPlayerByType(string type, Dictionary<string, OrderedSet<Player>> ranking)
        {
            // why it return IEnumerable instead of IQUeryable
            // too slow ...
            //var topFive = ranking.FindAll(p => p.Type == type)
            //                     .OrderBy(p => p.Name)
            //                     .ThenByDescending(p => p.Age)
            //                     .Take(5);

            var topFive = new List<Player>();
            if (ranking.ContainsKey(type))
            {
                topFive = ranking[type].Take(5).ToList();
            }

            Console.WriteLine("Type {0}: {1}", type, string.Join("; ", topFive));
        }

        static void AddPlayer(Player p, BigList<Player> ranking)
        {
            if (ranking.Count >= p.Position)
            {
                ranking.Insert(p.Position - 1, p);
            }
            else
            {
                ranking.Add(p);
            }
            Console.WriteLine("Added player {0} to position {1}", p.Name, p.Position);
        }

        static void Ranklist(int from, int to, BigList<Player> ranking)
        {
            int pos = from;
            var topPlayers = ranking.Range(from - 1, to - from + 1)
                                    .Select(s =>
                                    {
                                        return string.Format("{0}. {1}", pos++, s);
                                    });

            Console.WriteLine(string.Join("; ", topPlayers));

        }
    }
}
