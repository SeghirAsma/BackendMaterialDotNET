using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockManagement.Business.Interfaces;
using stockManagement.Data.Models;
using System.Collections.Generic;

namespace stockManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("getListEmployee")]
        public List<Employee> GetListEmployee()
        {
            List<Employee> employees = new List<Employee>();
            employees = _employeeService.ListEmployee();
            return(employees);
        }

        [HttpPost("addEmployee")]
        public Employee AddEmployee([FromBody] Employee employee)
        {
            Employee employeeToAdd = new Employee();
            employeeToAdd=_employeeService.AddEmployee(employee);
            return (employeeToAdd);

        }

        [HttpDelete("deleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            bool result = this._employeeService.DeleteEmployee(id);
            return Ok(result);
        }

        [HttpPut("updateEmployee")]
        public Employee UpdateEmployee([FromBody] Employee employee)
        {
            employee = _employeeService.UpdateEmployee(employee);
            return (employee);
        }

        [HttpGet("EmployeeById/{id}")]
        public Employee GetEmployeeByld(int id)
        {
            Employee employee = this._employeeService.GetEmployeeByld(id);
            return employee;
        }
    }
}
