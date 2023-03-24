using FluentValidation;

namespace Application.Features.TitleOperationClaims.Commands.Update;

public class UpdateTitleOperationClaimCommandValidator : AbstractValidator<UpdateTitleOperationClaimCommand>
{
    public UpdateTitleOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}