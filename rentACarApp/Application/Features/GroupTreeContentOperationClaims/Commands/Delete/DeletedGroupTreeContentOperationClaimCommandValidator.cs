using FluentValidation;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Delete;

public class DeleteGroupTreeContentOperationClaimCommandValidator : AbstractValidator<DeleteGroupTreeContentOperationClaimCommand>
{
    public DeleteGroupTreeContentOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}