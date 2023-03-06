using Application.Features.CarImages.Commands.Create;
using Application.Features.CarImages.Commands.Delete;
using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Queries.GetById;
using Application.Features.CarImages.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(IFormFile file, [FromQuery] int carId)
    {
        CreateCarImageCommand createCarImageCommand = new CreateCarImageCommand()
        {
            File=file,
            CarId = carId
        };
        CreatedCarImageResponse response = await Mediator.Send(createCarImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarImageCommand updateCarImageCommand)
    {
        UpdatedCarImageResponse response = await Mediator.Send(updateCarImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCarImageResponse response = await Mediator.Send(new DeleteCarImageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCarImageResponse response = await Mediator.Send(new GetByIdCarImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarImageQuery getListCarImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCarImageDto> response = await Mediator.Send(getListCarImageQuery);
        return Ok(response);
    }
}