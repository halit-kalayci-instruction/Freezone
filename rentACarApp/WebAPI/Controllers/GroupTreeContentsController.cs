using Application.Features.GroupTreeContents.Commands.Create;
using Application.Features.GroupTreeContents.Commands.Delete;
using Application.Features.GroupTreeContents.Commands.Update;
using Application.Features.GroupTreeContents.Queries.GetAll;
using Application.Features.GroupTreeContents.Queries.GetById;
using Application.Features.GroupTreeContents.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupTreeContentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGroupTreeContentCommand createGroupTreeContentCommand)
    {
        CreatedGroupTreeContentResponse response = await Mediator.Send(createGroupTreeContentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGroupTreeContentCommand updateGroupTreeContentCommand)
    {
        UpdatedGroupTreeContentResponse response = await Mediator.Send(updateGroupTreeContentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedGroupTreeContentResponse response = await Mediator.Send(new DeleteGroupTreeContentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdGroupTreeContentResponse response = await Mediator.Send(new GetByIdGroupTreeContentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGroupTreeContentQuery getListGroupTreeContentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGroupTreeContentDto> response = await Mediator.Send(getListGroupTreeContentQuery);
        return Ok(response);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        GetAllGroupTreeContentQuery getListGroupTreeContentQuery = new();
        var response = await Mediator.Send(getListGroupTreeContentQuery);
        return Ok(response);
    }
}