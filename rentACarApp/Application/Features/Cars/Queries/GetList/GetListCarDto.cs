using Application.Features.CarImages.Queries.GetList;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetListCarDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public int Kilometer { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }

        public short MinFindeksCreditRate { get; set; }

        public string Plate { get; set; }
        public CarState CarState { get; set; }
        public int ModelYear { get; set; }
        public List<GetListCarImageDto> Images { get; set; }
        //public List<CarImage> Images { get; set; }

    }
}