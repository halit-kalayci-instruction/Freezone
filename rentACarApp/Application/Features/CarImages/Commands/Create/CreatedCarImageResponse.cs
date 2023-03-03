namespace Application.Features.CarImages.Commands.Create;

public class CreatedCarImageResponse
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Path { get; set; }
}