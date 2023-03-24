using FluentValidation;

namespace Application.Features.UserTitleDefinitons.Commands.Update;

public class UpdateUserTitleDefinitonCommandValidator : AbstractValidator<UpdateUserTitleDefinitonCommand>
{
    public UpdateUserTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}