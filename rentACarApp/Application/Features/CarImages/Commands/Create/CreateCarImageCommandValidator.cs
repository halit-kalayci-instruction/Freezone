using FluentValidation;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommandValidator : AbstractValidator<CreateCarImageCommand>
{
    public CreateCarImageCommandValidator()
    {
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.Path).NotEmpty();
    }
}