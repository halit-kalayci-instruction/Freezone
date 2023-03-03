namespace Application.Features.CarImages.Queries.GetById;

public class GetByIdCarImageResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Path { get; set; }
}