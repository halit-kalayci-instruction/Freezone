using FluentValidation;

namespace Application.Features.TitleDefinitons.Commands.Delete;

public class DeleteTitleDefinitonCommandValidator : AbstractValidator<DeleteTitleDefinitonCommand>
{
    public DeleteTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}