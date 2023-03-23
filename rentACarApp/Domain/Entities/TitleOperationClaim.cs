using Freezone.Core.Persistence.Repositories;
using Freezone.Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TitleOperationClaim : Entity
    {
        public int TitleDefinitionId { get; set; }
        public int OperationClaimId { get; set; }
        public virtual TitleDefiniton TitleDefiniton { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

    }
}
