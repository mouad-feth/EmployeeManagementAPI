using EmployeeManagementApi.Data;
using MediatR;

namespace EmployeeManagementApi.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly EmployeeContext _context;

        public DeleteEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with ID {request.Id} not found.");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}