using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Business.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> ListEmployee();
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);

        Employee GetEmployeeByld(int id);
    }
}
