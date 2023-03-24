using Domain.Entities;
using Freezone.Core.Security.Entities;

namespace Application.Features.GroupTreeContents.Queries.GetAll
{
    public class GetAllGroupTreeContentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string Target { get; set; }
        public string ImgUrl { get; set; }
        public string NavigateUrl { get; set; }
        public int RowOrder { get; set; }
        public GroupTreeContentType Type { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
