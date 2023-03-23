using Domain.Entities;

namespace Application.Features.GroupTreeContents.Commands.Create;

public class CreatedGroupTreeContentResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ParentId { get; set; }
    public string Target { get; set; }
    public string ImgUrl { get; set; }
    public string NavigateUrl { get; set; }
    public int RowOrder { get; set; }
    public GroupTreeContentType Type { get; set; }
}