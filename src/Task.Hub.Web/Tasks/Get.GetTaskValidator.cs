using FastEndpoints;
using FluentValidation;
using Task.Hub.Web.Utility;

namespace Task.Hub.Web.Endpoints.TaskEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetTaskValidator : Validator<GetTaskRequest>
{

    public GetTaskValidator()
    {
        RuleFor(x => x.Uid)
                .NotEmpty().WithMessage("Value is required.")
                .Must(GuidValidator.BeValidGuid).WithMessage("Invalid GUID format.");
    }


}
