using FluentValidation;

namespace EmployeeManagementApi.Commands
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Employee Id is required.")
                .Must(id => id != Guid.Empty).WithMessage("Valid Employee Id is required.");
        }
    }
}