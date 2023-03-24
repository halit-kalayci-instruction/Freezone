using FluentValidation;

namespace Application.Features.TitleOperationClaims.Commands.Delete;

public class DeleteTitleOperationClaimCommandValidator : AbstractValidator<DeleteTitleOperationClaimCommand>
{
    public DeleteTitleOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}