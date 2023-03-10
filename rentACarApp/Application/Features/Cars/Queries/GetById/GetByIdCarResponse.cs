using Domain.Enums;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarResponse
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public int BrandId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public CarState CarState { get; set; }
    public short MinFindeksCreditRate { get; set; }
}