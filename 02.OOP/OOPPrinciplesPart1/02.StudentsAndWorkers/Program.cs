using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student("doesnt", "matter", (i % 5) + 2));
            }
            var sortedStudentsByGrade = students
                .OrderBy(x => x.Grade)
                .ToArray();

            Random r = new Random();
            var workers = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                workers.Add(new Worker("asd", "123", r.Next(100, 1000), r.Next(2, 10)));
            }

            var sortedWorkersByMoneyPerHourDesc = workers
                .OrderBy(w => -w.MoneyPerHour())
                .ToArray();

            var merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);

            var sortedByFirstAndLastName = merged
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToArray();

        }
    }
}
