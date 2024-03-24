using FastEndpoints;
using FluentValidation;
using Task.Hub.Web.Utility;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;
public class DeleteTaskValidator : Validator<DeleteTaskRequest>
{
    public DeleteTaskValidator()
    {
        RuleFor(x => x.Uid)
                .NotEmpty().WithMessage("Value is required.")
                .Must(GuidValidator.BeValidGuid).WithMessage("Invalid GUID format.");
    }

   
}
