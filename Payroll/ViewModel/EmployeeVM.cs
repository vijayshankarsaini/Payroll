using Microsoft.AspNetCore.Mvc.Rendering;
using Payroll.DropDownList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Payroll.ViewModel
{
    /// <summary>
    /// This view model contains employee properties
    /// </summary>
    public class EmployeeVM
    {
        /// <summary>
        /// This property contains employee id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This property contains employee name.
        /// </summary>
        [Required(ErrorMessage ="Please enter the employee name")]
        public string Name { get; set; }

        /// <summary>
        /// This property contains employee date of birth.
        /// </summary>
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please enter the employee date of birth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// This property contains employee date of birth.
        /// </summary>
        [Required(ErrorMessage ="Please enter the employee TIN")]
        public int TIN { get; set; }

        /// <summary>
        /// This property contains employee type value
        /// </summary>
        [Display(Name = "Employee Type")]
        public int EmployeeType { get; set; }

        /// <summary>
        /// This property contains employee type name
        /// </summary>
        [Display(Name = "Employee Type")]
        public string EmployeeTypeName { get; set; }

        public double Days { get; set; }

        /// <summary>
        /// This property contains of employee type list
        /// </summary>
        public List<SelectListItem> EmployeeTypes => EmployeeTypeList.GetEmployeeTypeList();
    }
}
