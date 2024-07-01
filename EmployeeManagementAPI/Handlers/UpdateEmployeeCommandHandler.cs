using AutoMapper;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Data;
using MediatR;

namespace EmployeeManagementApi.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly EmployeeContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            {
                throw new ApplicationException($"Employee with ID {request.Id} not found.");

            }
            _mapper.Map(request, employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }


    }
}