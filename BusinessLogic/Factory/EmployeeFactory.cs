using BusinessLogic.Interface;
using Constants;

namespace BusinessLogic.Factory
{
    /// <summary>
    /// This is a abstract factory class for employee
    /// </summary>
    public abstract class EmployeeFactory
    {
        /// <summary>
        /// This factory method will create the object of employee class based on given employee type
        /// </summary>
        /// <param name="employeeTypes">Employee type</param>
        /// <param name="absentDays">Absent days</param>
        /// <param name="workingDays">Working days</param>
        /// <returns>Object of IEmployee</returns>
        public abstract IEmployee GetEmployee(EmployeeTypes employeeTypes, double? absentDays, double? workingDays);
    }
}
