using EmployeeManagementApi.Models.Entities;
using MediatR;

namespace EmployeeManagementApi.Queries
{
    public class GetEmployeeQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }

    }
}
