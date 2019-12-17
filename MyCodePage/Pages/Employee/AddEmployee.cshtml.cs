using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCode.Services;

namespace MyCodePage.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public MyCode.Models.Employee Employee { get; set; }

        public AddEmployeeModel(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }


        public async Task<IActionResult> OnPostAsync(int departmentId)
        {
            Employee.DepartmentId = departmentId;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employeeService.add(Employee);

            return RedirectToPage("EmployeeList", new { departmentId });
        }
    }
}
