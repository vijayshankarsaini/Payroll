using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Factory;
using BusinessLogic.Interface;
using Constants;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Payroll.ViewModel;

namespace Payroll.Controllers
{
    public class EmployeeController : Controller
    {
        private IDAEmployee DaEmployee => new DAEmployee();

        public IActionResult Index()
        {
            return View(new EmployeeVM());
        }

        public JsonResult GetList()
        {
            var employees = DaEmployee.GetEmployees();
            List<EmployeeVM> list = new List<EmployeeVM>();
            foreach (var employee in employees)
            {
                list.Add(new EmployeeVM
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    DateOfBirth = employee.DateOfBirth.ToString("dd-MMM-yyyy"),
                    EmployeeType = Convert.ToInt16(employee.EmployeeType),
                    EmployeeTypeName = Enum.GetName(typeof(EmployeeTypes), employee.EmployeeType),
                    TIN = employee.TIN
                });
            }
            return Json(list);
        }

        public JsonResult GetData(int id)
        {
            var employee = DaEmployee.GetEmployee(id);
            EmployeeVM employeeVM = new EmployeeVM
            {
                Id = employee.Id,
                Name = employee.Name,
                TIN = employee.TIN,
                DateOfBirth = employee.DateOfBirth.ToString("dd-MMM-yyyy"),
                EmployeeType = Convert.ToInt16(employee.EmployeeType)
            };
            return Json(employeeVM);
        }

        [HttpPost]
        public JsonResult Action(string str, int mod)
        {
            try
            {
                Employee employee = new Employee();
                employee = JsonConvert.DeserializeObject<Employee>(str);
                
                if (mod == Convert.ToInt16(OperationMode.Create))
                {
                    DaEmployee.Create(employee);
                    return Json("0|Record Added Successfully");
                }
                else if (mod == Convert.ToInt16(OperationMode.Update))
                {
                    DaEmployee.Update(employee);
                    return Json("0|Record Updated Successfully");
                }
                else if (mod == Convert.ToInt16(OperationMode.Delete))
                {
                    DaEmployee.Delete(employee.Id);
                    return Json("0|Record Deleted Successfully");
                }
                else if (mod == Convert.ToInt16(OperationMode.Salary))
                {
                    EmployeeVM employeeVM = JsonConvert.DeserializeObject<EmployeeVM>(str);
                    double? workingDays = employeeVM.EmployeeType == Convert.ToInt16(EmployeeTypes.Contractual) ? Convert.ToDouble(employeeVM.Days) : Convert.ToDouble(null);
                    double? absentDays = employeeVM.EmployeeType == Convert.ToInt16(EmployeeTypes.Regular) ? Convert.ToDouble(employeeVM.Days) : Convert.ToDouble(null);

                    EmployeeFactory factory = new Factory();
                    IEmployee employeeObj = factory.GetEmployee(employee.EmployeeType, absentDays, workingDays);
                    double salary = employeeObj.GetSalary();
                    return Json("2|" + salary);
                }
                else // Error
                {
                    return Json("1|Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Json("1|" + ex.Message);
            }
        }
    }
}