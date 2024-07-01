using EmployeeManagementApi.Models.Entities;
using MediatR;

namespace EmployeeManagementApi.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
