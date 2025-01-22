using Kendo.Data;
using Kendo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            return Json(employees);
        }

       
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Json(employee);
            }
            return BadRequest(ModelState);
        }

   
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.Position = employee.Position;
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.Extension = employee.Extension;
                    existingEmployee.Address = employee.Address;
                    existingEmployee.ReportsTo = employee.ReportsTo;

                    _context.SaveChanges();
                    return Json(existingEmployee);
                }
                return NotFound($"Employee with ID {employee.EmployeeID} not found.");
            }
            return BadRequest(ModelState);
        }

       
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return Json(new { success = true, message = "Employee deleted successfully." });
            }
            return NotFound($"Employee with ID {id} not found.");
        }
    }
}
