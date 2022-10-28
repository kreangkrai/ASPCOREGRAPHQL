using ASPCOREGRAPHQL.Context;
using ASPCOREGRAPHQL.Interface;
using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Service
{
    public class EmployeeReposirory : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeReposirory(DataContext context)
        {
            _context = context;
        }

        public string Delete(string id)
        {
            var employee = _context.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return "Done";
            }
            return "Error";
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = from emp in _context.Employees
                         join dep in _context.Departments on emp.DepartmentId equals dep.DepartmentId into Dep

                         from d in Dep.DefaultIfEmpty()
                         select new Employee()
                         {
                             EmployeeId = emp.EmployeeId,
                             DepartmentId = d.Name,
                             Name = emp.Name,
                             Salary = emp.Salary
                         };
            return result.ToList();
        }

        public IEnumerable<EmployeeDetail> GetByGroup()
        {
            var result = (from emp in _context.Employees
                          join dep in _context.Departments on emp.DepartmentId equals dep.DepartmentId
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
            _context.Employees.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Employee Update(string id, Employee model)
        {
            var employee = _context.Employees.FirstOrDefault(s => s.EmployeeId == id);
            if (employee != null)
            {
                //string command = string.Format($@"update Employee Set Name = '{model.Name}', Salary = {model.Salary} where EmployeeId = '{id}'");
                //_dataContext.Database.ExecuteSqlRaw(command);
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                _context.SaveChanges();
                return model;
            }
            return null;
        }
    }
}