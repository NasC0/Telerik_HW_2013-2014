/* Task 2. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay 
 * and method MoneyPerHour() that returns money earned by hour by the worker. */

namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        public double MoneyPerHour()
        {
            double daySalary = (double)this.WeekSalary / 7;
            return daySalary / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return string.Format("{0}, Week Salary: {1}, Work Day: {2}", base.ToString(), this.WeekSalary, this.WorkHoursPerDay);
        }
    }
}
