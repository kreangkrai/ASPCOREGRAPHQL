using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}
