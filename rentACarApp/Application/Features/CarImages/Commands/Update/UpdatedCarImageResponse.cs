namespace Application.Features.CarImages.Commands.Update;

public class UpdatedCarImageResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Path { get; set; }
}