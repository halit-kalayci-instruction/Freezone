using Application.Features.TitleDefinitons.Commands.Create;
using Application.Features.TitleDefinitons.Commands.Delete;
using Application.Features.TitleDefinitons.Commands.Update;
using Application.Features.TitleDefinitons.Queries.GetById;
using Application.Features.TitleDefinitons.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleDefinitonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTitleDefinitonCommand createTitleDefinitonCommand)
    {
        CreatedTitleDefinitonResponse response = await Mediator.Send(createTitleDefinitonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTitleDefinitonCommand updateTitleDefinitonCommand)
    {
        UpdatedTitleDefinitonResponse response = await Mediator.Send(updateTitleDefinitonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTitleDefinitonResponse response = await Mediator.Send(new DeleteTitleDefinitonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTitleDefinitonResponse response = await Mediator.Send(new GetByIdTitleDefinitonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleDefinitonQuery getListTitleDefinitonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTitleDefinitonDto> response = await Mediator.Send(getListTitleDefinitonQuery);
        return Ok(response);
    }
}