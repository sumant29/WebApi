using Employee.EmployeeData;
using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData) 
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee!=null)
            {
                return Ok(employee);
            }
                return NotFound("Employee not present");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employees employees)
        {
            _employeeData.AddEmployee(employees);
            return Ok(employees);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee!=null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok("Employee Deleted");
            }
            return NotFound("Employee Not Found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id,Employees employees)
        {
            var existingemployee = _employeeData.GetEmployee(id);
            if (existingemployee != null)
            {
                employees.Id = existingemployee.Id;
                _employeeData.EditEmployee(employees);
                return Ok(employees);
            }
            return NotFound("Employee Not Found");
        }
    }
}
