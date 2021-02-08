using Constants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payroll.DropDownList
{
    public static class EmployeeTypeList
    {
        /// <summary>
        /// This method is used for getting list of employee types
        /// </summary>
        /// <returns>List of SelectListItem object</returns>
        public static List<SelectListItem> GetEmployeeTypeList()
        {
            return
                Enum.GetValues(typeof(EmployeeTypes)).Cast<EmployeeTypes>().Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = ((int)s).ToString()
                }).ToList();

        }
    }
}
