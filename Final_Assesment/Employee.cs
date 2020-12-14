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
        public decimal salary { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            throw new NotImplementedException();
        }
    }

    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public override decimal CalculateMonthlyPay()
        {
            throw new NotImplementedException();
        }
    }
}
