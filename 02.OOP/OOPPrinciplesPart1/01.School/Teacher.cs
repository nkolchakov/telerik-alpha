using System;
using System.Collections.Generic;

namespace _01.School
{
    public class Teacher : Person
    {
        private ISet<Discipline> disciplines;

        public Teacher(string name, ISet<Discipline> disciplinesSet)
            : base(name)
        {
            this.disciplines = disciplinesSet;
        }

        public void AddDiscipline(Discipline disc)
        {
            if (disc == null)
            {
                throw new ArgumentNullException("Discipline cannot be null");
            }
            this.disciplines.Add(disc);
        }

        public IEnumerable<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }
    }
}