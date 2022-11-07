using ASPCOREGRAPHQL.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLTypes
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType()
        {
            Field(x => x.DepartmentId, type: typeof(IdGraphType)).Description("Department ID");
            Field(x => x.Name).Description("Name Department");
        }
    }
}
