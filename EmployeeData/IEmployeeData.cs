using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;

namespace Employee.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employees> GetEmployees();

        Employees GetEmployee(Guid id);
        Employees AddEmployee(Employees employees);

        Employees EditEmployee(Employees employees);

        Employees DeleteEmployee(Employees employees);

    }
}
