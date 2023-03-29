using FluentValidation;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Update;

public class UpdateGroupTreeContentOperationClaimCommandValidator : AbstractValidator<UpdateGroupTreeContentOperationClaimCommand>
{
    public UpdateGroupTreeContentOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}