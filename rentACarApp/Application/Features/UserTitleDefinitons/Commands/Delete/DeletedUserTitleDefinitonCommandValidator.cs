using FluentValidation;

namespace Application.Features.UserTitleDefinitons.Commands.Delete;

public class DeleteUserTitleDefinitonCommandValidator : AbstractValidator<DeleteUserTitleDefinitonCommand>
{
    public DeleteUserTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}