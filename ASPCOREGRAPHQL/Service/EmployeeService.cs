using ASPCOREGRAPHQL.Context;
using ASPCOREGRAPHQL.Interface;
using ASPCOREGRAPHQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly DataContext _dataContext;
        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string Delete(string id)
        {
            var employee = _dataContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                _dataContext.Employees.Remove(employee);
                _dataContext.SaveChanges();
                return "Done";
            }
            return "Error";
        }

        public List<Employee> Get()
        {
            var result = from emp in _dataContext.Employees
                         join dep in _dataContext.Departments on emp.DepartmentId equals dep.DepartmentId into Dep

                         from d in Dep.DefaultIfEmpty()
                         select new Employee()
                         {
                             EmployeeId = emp.EmployeeId,
                             DepartmentId = d.Name,
                             Name = emp.Name,
                             Salary = emp.Salary
                         };
            //var re = _dataContext.Employees.FromSqlRaw("Select * from Employee order by Name").ToList();


            return result.ToList();
        }

        public List<EmployeeDetail> GetByGroup()
        {
            var result = (from emp in _dataContext.Employees
                          join dep in _dataContext.Departments on emp.DepartmentId equals dep.DepartmentId
                          group emp by dep.Name into Data
                          select new EmployeeDetail()
                          {
                              Department = Data.Key,
                              Salary = Data.Sum(s => s.Salary)
                          }).ToList();

            //string command = string.Format($@"select Department.Name as DepartmentId,
            //                                Sum(Employee.Salary) as Salary
            //                                from Employee
            //                                left join Department on Department.DepartmentId = Employee.DepartmentId
            //                                group by Department.Name");
            //var resultx = _dataContext.Employees.FromSqlRaw(command).Select(s=> new EmployeeDetail(){ Department = s.DepartmentId, Salary = s.Salary}).ToList();

            return result;
        }

        public Employee Insert(Employee model)
        {
            _dataContext.Employees.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public Employee Update(string id,Employee model)
        {
            var employee = _dataContext.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                //string command = string.Format($@"update Employee Set Name = '{model.Name}', Salary = {model.Salary} where EmployeeId = '{id}'");
                //_dataContext.Database.ExecuteSqlRaw(command);
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                _dataContext.SaveChanges();
                return model;
            }
            return null;
        }
    }
}