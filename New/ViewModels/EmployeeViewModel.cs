using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public string Dept { get; set; }
        public decimal Salary { get; set; }
        public IFormFile Images { get; set; }
    }
}
