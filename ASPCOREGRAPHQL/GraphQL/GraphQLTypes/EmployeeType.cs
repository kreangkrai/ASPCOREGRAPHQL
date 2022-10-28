using ASPCOREGRAPHQL.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.EmployeeId, type: typeof(IdGraphType)).Description("Employee ID");
            Field(x => x.DepartmentId).Description("Department ID");
            Field(x => x.Name).Description("Name Employee");
            Field(x => x.Salary).Description("Salary Employee");
        }
    }
}