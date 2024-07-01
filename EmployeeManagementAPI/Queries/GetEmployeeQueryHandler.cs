using EmployeeManagementApi.Data;
using EmployeeManagementApi.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagementApi.Queries
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
    {
        private readonly EmployeeContext _context;

        public GetEmployeeQueryHandler(EmployeeContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));


        }

        /*
        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {

                return await _context.Employees.FindAsync(request.Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred while retrieving employee with ID {request.Id}", ex);
            }

        }
        */
        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "Request object is null.");
                }

                var employee = await _context.Employees.FindAsync(request.Id);

                if (employee == null)
                {
                    throw new InvalidOperationException($"Employee with ID {request.Id} not found.");
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occurred while retrieving employee with ID {request?.Id}", ex);
            }
        }

    }
}