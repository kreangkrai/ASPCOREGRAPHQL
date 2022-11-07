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

        public Employee GetById(string id)
        {
            var result = from emp in _context.Employees
                         join dep in _context.Departments on emp.DepartmentId equals dep.DepartmentId into Dep                        
                         from d in Dep.DefaultIfEmpty()
                         where emp.EmployeeId.Equals(id)
                         select new Employee()
                         {
                             EmployeeId = emp.EmployeeId,
                             DepartmentId = d.Name,
                             Name = emp.Name,
                             Salary = emp.Salary
                         };
            return result.FirstOrDefault();
        }

        public Employee Insert(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Employee Update(Employee model)
        {
            var employee = _context.Employees.FirstOrDefault(s => s.EmployeeId == model.EmployeeId);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                _context.SaveChanges();
                return model;
            }
            return null;
        }
    }
}