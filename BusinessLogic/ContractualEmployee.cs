using BusinessLogic.Interface;
using System;

namespace BusinessLogic
{
    public class ContractualEmployee : IEmployee
    {
        private const double RatePerDay = 500;

        private double? WorkingDays { get; set; }

        public ContractualEmployee(double? _workingDays)
        {
            WorkingDays = _workingDays;
        }

        /// <summary>
        /// This method is used for calculating contractual employee salary
        /// </summary>
        /// <returns>Returns salary</returns>
        public double GetSalary()
        {
            try
            {
                double salary = Math.Round((RatePerDay * Convert.ToDouble(WorkingDays)), 2);
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
