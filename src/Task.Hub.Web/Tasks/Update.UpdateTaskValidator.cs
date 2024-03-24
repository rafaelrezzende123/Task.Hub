using FastEndpoints;
using FluentValidation;
using Task.Hub.Web.Utility;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

public class UpdateTaskValidator : Validator<UpdateTaskRequest>
{
    public UpdateTaskValidator()
    {

        RuleFor(x => x.Uid)
          .Must((args, Uid) => args.TaskUid == Uid)
          .WithMessage("Task and body Ids must match; cannot update Id of an existing resource.");


        RuleFor(x => x.Title)
          .NotEmpty()
          .WithMessage("Origin is required.")
          .MinimumLength(3);

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Destination is required.")
            .MinimumLength(3);

        RuleFor(x => x.DueDate)
              .NotNull()
              .WithMessage("Value is required.")
              .Must(DateValidator.BeValidDueDate).WithMessage("Due date must be greater than or equal to today.");


        RuleFor(x => x.IsCompleted)
           .NotNull().WithMessage("Value is required.");
    }
}
