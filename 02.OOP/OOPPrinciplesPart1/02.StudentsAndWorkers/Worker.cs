using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    public class Worker : Human
    {
        private const int WORK_DAYS = 5;
        private const int WORK_HOURS_PER_DAY = 8;

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (weekSalary < 0)
                {
                    throw new ArgumentOutOfRangeException("Week salary cannot be less than 0.");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (workHoursPerDay < 0)
                {
                    throw new ArgumentOutOfRangeException("Work hours per day cannot be less than 0.");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / WORK_DAYS * this.WorkHoursPerDay;
        }
    }
}
