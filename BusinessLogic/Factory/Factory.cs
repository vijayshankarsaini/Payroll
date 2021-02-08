using BusinessLogic.Interface;
using Constants;
using System;

namespace BusinessLogic.Factory
{
    public class Factory : EmployeeFactory
    {
        public override IEmployee GetEmployee(EmployeeTypes employeeTypes, double? absentDays, double? workingDays)
        {
            switch (employeeTypes)
            {
                case EmployeeTypes.Regular:
                    return new RegularEmployee(absentDays);
                case EmployeeTypes.Contractual:
                    return new ContractualEmployee(workingDays);
                default:
                    throw new ApplicationException("Employee object cannot be created");
            }
        }
    }
}
