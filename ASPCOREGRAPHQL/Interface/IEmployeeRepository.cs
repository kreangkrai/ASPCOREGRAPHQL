using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(string id);
        Employee Insert(Employee model);
        Employee Update(Employee model);
        string Delete(string id);
    }
}
