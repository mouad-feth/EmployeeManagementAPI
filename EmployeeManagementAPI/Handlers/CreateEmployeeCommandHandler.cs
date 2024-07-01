using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Models.Entities;
using EmployeeManagementApi.Data;

namespace EmployeeManagementApi.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly EmployeeContext _context;

        public CreateEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Position = request.Position,
                    Department = request.Department

                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(cancellationToken);



                return employee.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while creating employee", ex);
            }
        }
    }
}