using FluentValidation;

namespace Application.Features.TitleDefinitons.Commands.Create;

public class CreateTitleDefinitonCommandValidator : AbstractValidator<CreateTitleDefinitonCommand>
{
    public CreateTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}