using ASPCOREGRAPHQL.Context;
using ASPCOREGRAPHQL.Interface;
using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Service
{
    public class DepartmentService : IDepartment
    {
        private readonly DataContext _dataContext;
        public DepartmentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string Delete(string id)
        {
            var department = _dataContext.Departments.FirstOrDefault(s => s.DepartmentId == id);
            if (department != null)
            {
                _dataContext.Departments.Remove(department);
                _dataContext.SaveChanges();
                return "Done";
            }
            return "Error";
        }

        public List<Department> Get()
        {         
            List<Department> datas =  _dataContext.Departments.ToList();
            return datas;
        }

        public Department Insert(Department model)
        {
            _dataContext.Departments.Add(model);
            _dataContext.SaveChanges();
            return model;
        }

        public Department Update(string id, Department model)
        {
            var department = _dataContext.Departments.FirstOrDefault(s => s.DepartmentId == id);
            if (department != null)
            {
                department.Name = model.Name;
                _dataContext.SaveChanges();
                return model;
            }
            return null;
        }
    }
}
