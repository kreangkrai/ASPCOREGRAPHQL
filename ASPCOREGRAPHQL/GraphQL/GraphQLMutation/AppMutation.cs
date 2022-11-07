using ASPCOREGRAPHQL.GraphQL.GraphQLTypes;
using ASPCOREGRAPHQL.Interface;
using ASPCOREGRAPHQL.Models;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCOREGRAPHQL.GraphQL.GraphQLMutation
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IEmployeeRepository employee,IDepartmentRepository department)
        {
            Field<EmployeeType>(
                "insertEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }),
                resolve: context =>
                {
                    var emp = context.GetArgument<Employee>("employee");
                    return employee.Insert(emp);
                }
            );
            Field<EmployeeType>(
                "updateEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee"}),
                resolve: context =>
                {
                    var emp = context.GetArgument<Employee>("employee");                 
                    return employee.Update(emp);
                }
            );
            Field<StringGraphType>(
                "deleteEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "employeeId"}),
                resolve: context =>
                {
                    var emp = context.GetArgument<string>("employeeId");
                    var message = employee.Delete(emp);
                    return message;
                }
            );

            Field<DepartmentType>(
                "insertDepartment",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<DepartmentInputType>> { Name = "department" }),
                resolve: context =>
                {
                    var dep = context.GetArgument<Department>("department");
                    return department.Insert(dep);
                }
            );
        }
    }
}
