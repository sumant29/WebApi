using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;

        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employees AddEmployee(Employees employees)
        {
            employees.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employees);
            _employeeContext.SaveChanges();
            return employees;
        }

        public Employees DeleteEmployee(Employees employees)
        {
            _employeeContext.Employees.Remove(employees);
            _employeeContext.SaveChanges();
            return employees;
        }

        public Employees EditEmployee(Employees employees)
        {
            var existingEmployee = _employeeContext.Employees.Find(employees.Id);
            if(existingEmployee != null)
            {
                existingEmployee.Name = employees.Name;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employees;
        }

        public Employees GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employees> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
