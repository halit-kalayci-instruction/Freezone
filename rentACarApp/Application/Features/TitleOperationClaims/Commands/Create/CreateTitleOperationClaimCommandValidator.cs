using FluentValidation;

namespace Application.Features.TitleOperationClaims.Commands.Create;

public class CreateTitleOperationClaimCommandValidator : AbstractValidator<CreateTitleOperationClaimCommand>
{
    public CreateTitleOperationClaimCommandValidator()
    {
        RuleFor(c => c.TitleDefinitionId).NotEmpty();
        RuleFor(c => c.OperationClaimId).NotEmpty();
    }
}