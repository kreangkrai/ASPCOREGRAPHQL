using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLTypes
{
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "employeeInput";
            Field<NonNullGraphType<StringGraphType>>("EmployeeId");
            Field<NonNullGraphType<StringGraphType>>("DepartmentId");
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<IntGraphType>>("Salary");
        }  
    }
}
