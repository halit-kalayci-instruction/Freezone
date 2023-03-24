namespace Application.Features.TitleOperationClaims.Queries.GetList;

public class GetListTitleOperationClaimDto
{
    public int Id { get; set; }
    public int TitleDefinitionId { get; set; }
    public int OperationClaimId { get; set; }
}