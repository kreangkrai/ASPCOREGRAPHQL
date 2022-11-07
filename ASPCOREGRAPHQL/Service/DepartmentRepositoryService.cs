using ASPCOREGRAPHQL.Context;
using ASPCOREGRAPHQL.Interface;
using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Service
{
    public class DepartmentRepositoryService : IDepartmentRepository
    {
        private readonly DataContext _dataContext;
        public DepartmentRepositoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Department Insert(Department model)
        {
            _dataContext.Departments.Add(model);
            _dataContext.SaveChanges();
            return model;
        }
    }
}
