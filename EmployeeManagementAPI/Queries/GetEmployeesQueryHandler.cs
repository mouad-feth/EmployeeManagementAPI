using EmployeeManagementApi.Data;
using EmployeeManagementApi.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Queries
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {

        private readonly EmployeeContext _context;


        public GetEmployeesQueryHandler(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            try {
                return await _context.Employees.ToListAsync(cancellationToken);
            } catch (Exception ex) {
                throw new ApplicationException("Error occurred while fetching employees.", ex);
            }

        }


    }
}