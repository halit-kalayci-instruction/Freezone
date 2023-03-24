namespace Application.Features.TitleOperationClaims.Commands.Update;

public class UpdatedTitleOperationClaimResponse
{
    public int Id { get; set; }
    public int TitleDefinitionId { get; set; }
    public int OperationClaimId { get; set; }
}