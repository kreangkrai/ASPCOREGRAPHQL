using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Interface
{
    public interface IEmployee
    {
        List<Employee> Get();
        Employee Insert(Employee model);
        List<EmployeeDetail> GetByGroup();
        Employee Update(string id,Employee model);
        string Delete(string id);
    }
}
