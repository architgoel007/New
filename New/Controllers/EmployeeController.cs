using Microsoft.AspNetCore.Mvc;
using OurProject.Models;
using OurProject.ViewModels;
using System;
using System.IO;

namespace OurProject.Controllers
{
    public class EmployeeController : Controller
    { 

        public IEmployee Employee { get; }

        private object WebHostEnvironment;

        public EmployeeController(IEmployee _employee)
        {
            Employee = _employee;
        }

        public IActionResult Index()
        {
            var emps = Employee.GetEmployees();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult Create(Employee employee)
        {
            Employee.AddEmployee(employee);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var r = Employee.DeleteEmployee(id);
            if (r)
            {
                ViewBag.message = "record delete successfully";
            }
            else
            {
                ViewBag.message = "record not deleted";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = Employee.GetEmployeeById(id);
            return View(emp);
        }
        
        [HttpPost]
        
        public IActionResult Update(Employee emp)
        {
            Employee.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        private string UploadedFile(EmployeeViewModel model)
        {
            string uniqueFileName = null;
            if (model.Images!= null)
            {;
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var Filestream=new FileStream(filePath, FileMode.Create))
                {
                    model.Images.CopyTo(Filestream);
                }
            }
            return uniqueFileName;
        }
    }
}
