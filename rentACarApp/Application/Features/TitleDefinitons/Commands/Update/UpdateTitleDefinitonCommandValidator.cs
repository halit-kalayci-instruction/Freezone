using FluentValidation;

namespace Application.Features.TitleDefinitons.Commands.Update;

public class UpdateTitleDefinitonCommandValidator : AbstractValidator<UpdateTitleDefinitonCommand>
{
    public UpdateTitleDefinitonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}