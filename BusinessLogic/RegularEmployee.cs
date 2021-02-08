using BusinessLogic.Interface;
using System;

namespace BusinessLogic
{
    public class RegularEmployee : IEmployee
    {
        private const double MonthDays = 22;

        private const double BasicSalary = 20000;

        private const double TaxPercentage = 12;

        private double? AbsentDays { get; set; }

        public RegularEmployee(double? _absentDays)
        {
            AbsentDays = _absentDays;
        }

        /// <summary>
        /// This method is used for calculating regular employee salary
        /// </summary>
        /// <returns>Returns salary</returns>
        public double GetSalary()
        {
            try
            {
                double salary = Math.Round(BasicSalary - (((BasicSalary * TaxPercentage) / 100) + ((BasicSalary / MonthDays) * Convert.ToDouble(AbsentDays))), 2);
                if (salary < 0)
                {
                    salary = 0;
                }
                return salary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
