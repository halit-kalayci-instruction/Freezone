namespace Application.Features.TitleOperationClaims.Commands.Create;

public class CreatedTitleOperationClaimResponse
{
    public int Id { get; set; }
    public int TitleDefinitionId { get; set; }
    public int OperationClaimId { get; set; }
}