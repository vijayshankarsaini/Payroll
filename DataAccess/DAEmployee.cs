using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    /// <summary>
    /// This class contains methods for employee data access
    /// </summary>
    public class DAEmployee : IDAEmployee
    {
        /// <summary>
        /// This method will return the employee detail based on given employee id.
        /// </summary>
        /// <param name="employee">Employee class object</param>
        /// <returns>Employee class object</returns>
        public Employee Create(Employee employee)
        {
            int rowCount = EmployeeList.EmpList.Count;
            int newId = 0;
            if (rowCount <= 0)
            {
                newId = 1;
            }
            else
            {
                newId = EmployeeList.EmpList.Max(s => s.Id) + 1;
            }
            employee.Id = newId;
            EmployeeList.EmpList.Add(employee);
            return employee;
        }

        /// <summary>
        /// This method is used for updating employee record
        /// </summary>
        /// <param name="employee">Employee class object</param>
        /// <returns>Return updated employee class object</returns>
        public Employee Update(Employee employee)
        {
            Employee employeeUpdated = EmployeeList.EmpList.Where(s => s.Id == employee.Id).FirstOrDefault();
            employeeUpdated.Name = employee.Name;
            employeeUpdated.TIN = employee.TIN;
            employeeUpdated.DateOfBirth = employee.DateOfBirth;
            employeeUpdated.EmployeeType = employee.EmployeeType;
            return employeeUpdated;
        }

        /// <summary>
        /// This method is used for deleting employee record
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Returns true if record deleted else false</true></returns>
        public bool Delete(int id)
        {
            try
            {
                Employee employee = EmployeeList.EmpList.Where(s => s.Id == id).FirstOrDefault();
                EmployeeList.EmpList.Remove(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method will return the employee detail based on given employee id.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Employee class object</returns>
        public Employee GetEmployee(int id)
        {
            return EmployeeList.EmpList.Where(s => s.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// This method will return the list of employees.
        /// </summary>
        /// <returns>List of Employee class object</returns>
        public List<Employee> GetEmployees()
        {
            return EmployeeList.EmpList.ToList();
        }
    }
}
