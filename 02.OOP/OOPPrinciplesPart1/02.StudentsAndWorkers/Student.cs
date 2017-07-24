using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    public class Student : Human
    {
        private const int MAX_GRADE = 6;
        private const int MIN_GRADE = 2;

        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < MIN_GRADE || value > MAX_GRADE)
                {
                    throw new ArgumentOutOfRangeException($"Grade must be between {MIN_GRADE} and {MAX_GRADE}");
                }
                this.grade = value;
            }
        }
    }
}
