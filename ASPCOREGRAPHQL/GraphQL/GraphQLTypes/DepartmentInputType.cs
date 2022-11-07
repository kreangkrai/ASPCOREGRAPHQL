using ASPCOREGRAPHQL.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLTypes
{
    public class DepartmentInputType : InputObjectGraphType
    {
        public DepartmentInputType()
        {
            Name = "departmentInput";
            Field<NonNullGraphType<StringGraphType>>("DepartmentId");
            Field<NonNullGraphType<StringGraphType>>("Name");
        }
    }
}
