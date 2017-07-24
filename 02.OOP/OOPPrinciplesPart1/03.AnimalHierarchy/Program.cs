using _03.AnimalHierarchy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal> {
               new Frog(13,"Froggy", Gender.Male),
               new Frog(5,"Froggy2", Gender.Female),
               new Kitten(2,"Missy"),
               new Kitten(2,"Kitty"),
               new Tomcat(3,"Maxi"),
               new Tomcat(5,"Tommy"),
               new Tomcat(10,"Maximilian"),
               new Dog(5,"Huskey", Gender.Male),
            };

            animals.ForEach(x => x.MakeSound());

            var groupedByType = animals.GroupBy(x => x.GetType().Name,
                                                x => new { Name = x.Name, Age = x.Age })
                                        .ToList();

            foreach (var animalGrouping in groupedByType)
            {
                /*
                 * animalGrouping = {Key:string, data:IEnumerable }
                 */
                string type = animalGrouping.Key;
                double avgAge = animalGrouping.Average(x => x.Age);
                Console.WriteLine($"Avareage age for {type} is {avgAge}");
            }
        }
    }
}
