using FluentValidation;

namespace Application.Features.CarImages.Commands.Delete;

public class DeleteCarImageCommandValidator : AbstractValidator<DeleteCarImageCommand>
{
    public DeleteCarImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}