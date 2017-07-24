using _03.AnimalHierarchy.Contracts;
using _03.AnimalHierarchy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public class Animal : ISound
    {
        private int age;
        private string name;

        public Animal(int age, string name, Gender gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public Gender Gender { get; private set; }

        public virtual void MakeSound()
        {
            Console.WriteLine("Default sound from an animal");
        }
    }
}
