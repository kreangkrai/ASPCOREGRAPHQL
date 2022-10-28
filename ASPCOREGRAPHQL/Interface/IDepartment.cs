using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Interface
{
    interface IDepartment
    {
        List<Department> Get();
        Department Insert(Department model);
        Department Update(string id,Department model);
        string Delete(string id);
    }
}
