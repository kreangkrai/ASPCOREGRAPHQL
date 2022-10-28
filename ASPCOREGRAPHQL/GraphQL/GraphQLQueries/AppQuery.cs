using ASPCOREGRAPHQL.GraphQL.GraphQLTypes;
using ASPCOREGRAPHQL.Interface;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        [Obsolete]
        public AppQuery(IEmployeeRepository employee)
        {
            Field<ListGraphType<EmployeeType>>(
                "employee",
                resolve:  Context => employee.GetAll()
            );
            
        }
    }
}
