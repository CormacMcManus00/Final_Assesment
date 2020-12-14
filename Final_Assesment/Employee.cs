using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Assesment
{
    abstract class Employee
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        abstract public decimal CalculateMonthlyPay();

        
    }

    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string firstname, string surname, decimal salary)
        {
            FirstName = firstname;
            SurName = surname;
            Salary = salary;
        }

        public override decimal CalculateMonthlyPay()
        {
            decimal pay = Salary / 12;
            return pay;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()},{FirstName} - Full Time");
        }
    }

    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string firstname, string surname, decimal hourlyrate, double hoursworked)
        {
            FirstName = firstname;
            SurName = surname;
            HourlyRate = hourlyrate;
            HoursWorked = hoursworked;
        }

        public override decimal CalculateMonthlyPay()
        {
            decimal pay = HourlyRate * Convert.ToDecimal(HoursWorked);
            return pay;
        }

        public override string ToString()
        {
            return string.Format($"{SurName.ToUpper()},{FirstName} - Part Time");
        }
    }
}
