using FluentValidation;

namespace Application.Features.UserTitleDefinitons.Commands.Create;

public class CreateUserTitleDefinitonCommandValidator : AbstractValidator<CreateUserTitleDefinitonCommand>
{
    public CreateUserTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.HrTitleDefinitonId).NotEmpty();
    }
}