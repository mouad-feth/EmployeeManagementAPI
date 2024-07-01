using MediatR;

namespace EmployeeManagementApi.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
