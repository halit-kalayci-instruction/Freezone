namespace Application.Features.GroupTreeContentOperationClaims.Commands.Create;

public class CreatedGroupTreeContentOperationClaimResponse
{
    public int Id { get; set; }
    public int GroupTreeContentId { get; set; }
    public int OperationClaimId { get; set; }
}