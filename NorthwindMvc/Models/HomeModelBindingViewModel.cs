using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindMvc.Models
{
    public class HomeModelBindingViewModel
    {
        public Thing Thing { get; set; }
        public bool HasErrors { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}
