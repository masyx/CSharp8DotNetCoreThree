using Packt.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindEmployees.MyFeature.Pages
{
    public class EmployeesPageModel : PageModel
    {
        private Northwind db;

        public IEnumerable<Employee> Employees { get; set; }

        public EmployeesPageModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }
    }
}
