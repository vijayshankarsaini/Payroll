using System.Collections.Generic;

namespace DataAccess
{
    /// <summary>
    /// This interface contains methods for employee data access
    /// </summary>
    public interface IDAEmployee
    {
        /// <summary>
        /// This method will return the employee detail based on given employee id.
        /// </summary>
        /// <param name="employee">Employee class object</param>
        /// <returns>Employee class object</returns>
        Employee Create(Employee employee);

        /// <summary>
        /// This method is used for updating employee record
        /// </summary>
        /// <param name="employee">Employee class object</param>
        /// <returns>Return updated employee class object</returns>
        Employee Update(Employee employee);

        /// <summary>
        /// This method is used for deleting employee record
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Returns true if record deleted else false</true></returns>
        bool Delete(int id);

        /// <summary>
        /// This method will return the employee detail based on given employee id.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Employee class object</returns>
        Employee GetEmployee(int id);

        /// <summary>
        /// This method will return the list of employees.
        /// </summary>
        /// <returns>List of Employee class object</returns>
        List<Employee> GetEmployees();
    }
}
