using ASPCOREGRAPHQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Interface
{
    public interface IDepartmentRepository
    {
        Department Insert(Department model);
    }
}
