using Application.Features.UserTitleDefinitons.Commands.Create;
using Application.Features.UserTitleDefinitons.Commands.Delete;
using Application.Features.UserTitleDefinitons.Commands.Update;
using Application.Features.UserTitleDefinitons.Queries.GetById;
using Application.Features.UserTitleDefinitons.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTitleDefinitonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserTitleDefinitonCommand createUserTitleDefinitonCommand)
    {
        CreatedUserTitleDefinitonResponse response = await Mediator.Send(createUserTitleDefinitonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserTitleDefinitonCommand updateUserTitleDefinitonCommand)
    {
        UpdatedUserTitleDefinitonResponse response = await Mediator.Send(updateUserTitleDefinitonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedUserTitleDefinitonResponse response = await Mediator.Send(new DeleteUserTitleDefinitonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdUserTitleDefinitonResponse response = await Mediator.Send(new GetByIdUserTitleDefinitonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserTitleDefinitonQuery getListUserTitleDefinitonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserTitleDefinitonDto> response = await Mediator.Send(getListUserTitleDefinitonQuery);
        return Ok(response);
    }
}