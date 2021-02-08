using BusinessLogic.Factory;
using BusinessLogic.Interface;
using DataAccess;
using System;
using Xunit;

namespace PayrollTest
{
    public class EmployeeSalaryUnitTest
    {
        [Fact]
        public void RegularEmployeeSalary()
        {
            IDAEmployee DaEmployee = new DAEmployee();
            double expectedSalary = 16236.36;
            double? absentDays = 1.5;
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Test1",
                EmployeeType = Constants.EmployeeTypes.Regular,
                DateOfBirth = new DateTime(2000, 1, 1),
                TIN = 12345
            };
            DaEmployee.Create(employee);
            EmployeeFactory factory = new Factory();
            IEmployee employeeObj = factory.GetEmployee(employee.EmployeeType, absentDays, null);
            double salary = employeeObj.GetSalary();
            Assert.Equal(expectedSalary, salary);
        }

        [Fact]
        public void ContractualEmployeeSalary()
        {
            IDAEmployee DaEmployee = new DAEmployee();
            double expectedSalary = 5250;
            double? workingDays = 10.5;
            Employee employee = new Employee
            {
                Id = 2,
                Name = "Test2",
                EmployeeType = Constants.EmployeeTypes.Contractual,
                DateOfBirth = new DateTime(2000, 2, 1),
                TIN = 123456
            };
            DaEmployee.Create(employee);
            EmployeeFactory factory = new Factory();
            IEmployee employeeObj = factory.GetEmployee(employee.EmployeeType, null, workingDays);
            double salary = employeeObj.GetSalary();
            Assert.Equal(expectedSalary, salary);
        }
    }
}
