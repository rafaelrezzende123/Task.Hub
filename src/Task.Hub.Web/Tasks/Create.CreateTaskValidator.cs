using FastEndpoints;
using FluentValidation;
using Task.Hub.Web.Utility;
namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public class CreateTaskValidator : Validator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(3);

        RuleFor(x => x.Description)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(3);

        RuleFor(x => x.DueDate)
          .NotNull()
          .WithMessage("Value is required.")
          .Must(DateValidator.BeValidDueDate).WithMessage("Due date must be greater than or equal to today.");

    }


}