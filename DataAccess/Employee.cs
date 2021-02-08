using Constants;
using System;

namespace DataAccess
{
    /// <summary>
    /// This class contains employee details
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// This property contains employee id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This property contains employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property contains employee date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// This property contains employee date of birth.
        /// </summary>
        public int TIN { get; set; }

        /// <summary>
        /// This property contains employee type
        /// </summary>
        public EmployeeTypes EmployeeType { get; set; }
    }
}
