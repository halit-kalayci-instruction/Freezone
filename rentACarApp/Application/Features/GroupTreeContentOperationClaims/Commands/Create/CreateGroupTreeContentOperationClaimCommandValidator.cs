using FluentValidation;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Create;

public class CreateGroupTreeContentOperationClaimCommandValidator : AbstractValidator<CreateGroupTreeContentOperationClaimCommand>
{
    public CreateGroupTreeContentOperationClaimCommandValidator()
    {
        RuleFor(c => c.GroupTreeContentId).NotEmpty();
        RuleFor(c => c.OperationClaimId).NotEmpty();
    }
}