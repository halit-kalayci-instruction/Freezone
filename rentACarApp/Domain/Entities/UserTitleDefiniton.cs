using Freezone.Core.Persistence.Repositories;
using Freezone.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserTitleDefiniton : Entity
    {
        public int UserId { get; set; }
        public int HrTitleDefinitonId { get; set; }
        public virtual User User { get; set; }
        public virtual TitleDefinition HrTitleDefiniton { get; set; }
    }
}
