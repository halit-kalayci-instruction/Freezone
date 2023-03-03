using FluentValidation;

namespace Application.Features.CarImages.Commands.Update;

public class UpdateCarImageCommandValidator : AbstractValidator<UpdateCarImageCommand>
{
    public UpdateCarImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}