using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NorthwindWeb.Pages
{
    public class IndexModel : PageModel
    {
        public string DayName { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Website";
            DayName = DateTime.Now.ToString("dddd");
        }
    }
}
