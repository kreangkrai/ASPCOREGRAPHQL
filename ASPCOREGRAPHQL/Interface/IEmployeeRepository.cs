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
        Employee Insert(Employee model);
        IEnumerable<EmployeeDetail> GetByGroup();
        Employee Update(string id, Employee model);
        string Delete(string id);
    }
}
