using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Models
{
    [Keyless]
    public class EmployeeDetail
    {
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
