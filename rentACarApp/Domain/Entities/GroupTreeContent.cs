using Freezone.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupTreeContent : Entity
    {
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string Target { get; set; }
        public string ImgUrl { get; set; }
        public string NavigateUrl { get; set; }
        public int RowOrder { get; set; }
        public GroupTreeContentType Type { get; set; }
        public virtual ICollection<GroupTreeContentOperationClaim> GroupTreeContentOperationClaims { get; set; }

        public GroupTreeContent()
        {
            GroupTreeContentOperationClaims = new HashSet<GroupTreeContentOperationClaim>();
        }
    }
}
