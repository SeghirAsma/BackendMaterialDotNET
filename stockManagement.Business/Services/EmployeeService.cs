using Microsoft.EntityFrameworkCore;
using stockManagement.Business.Interfaces;
using stockManagement.Data;
using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stockManagement.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBContextManagementStock _dbContext; //injection de dependance : on injecte le fichier dbcontext
        //constructeur
        public EmployeeService(DBContextManagementStock dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                //si notre objet employee non null on fait l'ajout dans la bdd
                if (employee != null)
                {
                    this._dbContext.Employees.Add(employee);
                    this._dbContext.SaveChanges();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                bool find = false;
                if (id != 0)
                {
                    Employee findEmp = this._dbContext.Employees.Find(id);
                    if (findEmp != null)
                    {
                        find = true;
                        this._dbContext.Employees.Remove(findEmp);
                        this._dbContext.SaveChanges();
                    }
                }
                return find;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> ListEmployee()
        {
            try
            {
                List<Employee> employee = this._dbContext.Employees
                                                         //.Include(x => x.Assignment)
                                                         .ToList(); //tolist c'est l'une des linq: on l'utilise pour la recuperation des donnees depuis la bdd
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee UpdateEmployee(Employee employee) {
            try
            {
                if (employee != null)
                {
                    if (employee.Id != 0)
                    {
                        this._dbContext.Employees.Update(employee);
                        this._dbContext.SaveChanges();
                    }
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeeByld(int id)
        {
            try
            {
                Employee findEmployee = new Employee();
                if (id != 0)
                {
                    findEmployee = this._dbContext.Employees.FirstOrDefault(x => x.Id == id);

                }
                return findEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
