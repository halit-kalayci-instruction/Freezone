using Freezone.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarImage : Entity
    {
        public int CarId { get; set; }
        public string Path { get; set; }
        public virtual Car Car { get; set; }

        public CarImage()
        {
        }

        public CarImage(string path, int carId)
        {
            Path = path;
            CarId = carId;
        }
    }
}
