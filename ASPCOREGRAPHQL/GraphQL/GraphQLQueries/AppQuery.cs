using ASPCOREGRAPHQL.GraphQL.GraphQLTypes;
using ASPCOREGRAPHQL.Interface;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IEmployeeRepository employee)
        {
            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve:  Context => employee.GetAll()
            );
            Field<EmployeeType>(
                "employee",
                arguments : new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "employeeId" }),
                resolve: context =>
                {
                    var empid = context.GetArgument<string>("employeeId");
                    return employee.GetById(empid);
                }
            );
        }
    }
}
