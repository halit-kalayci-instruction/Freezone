using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freezone.Core.Persistence.Repositories;

//TODO: Soft delete
// 0 pasif, 1 aktif
public class Entity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int Status { get; set; }

    public Entity()
    {
        Status = 1;
    }

    public Entity(int id)
    {
        Id = id;
        Status = 1;
    }
}
