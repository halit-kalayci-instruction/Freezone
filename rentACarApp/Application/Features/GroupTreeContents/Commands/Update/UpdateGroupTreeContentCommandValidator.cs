using FluentValidation;

namespace Application.Features.GroupTreeContents.Commands.Update;

public class UpdateGroupTreeContentCommandValidator : AbstractValidator<UpdateGroupTreeContentCommand>
{
    public UpdateGroupTreeContentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}