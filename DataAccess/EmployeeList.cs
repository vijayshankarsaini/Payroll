using System.Collections.Generic;

namespace DataAccess
{
    /// <summary>
    /// This class contains employee list into the memory
    /// </summary>
    public static class EmployeeList
    {
        static EmployeeList()
        {
            EmpList = new List<Employee>();
        }

        /// <summary>
        /// This property contains employee list
        /// </summary>
        public static IList<Employee> EmpList { get; set; }
    }
}
