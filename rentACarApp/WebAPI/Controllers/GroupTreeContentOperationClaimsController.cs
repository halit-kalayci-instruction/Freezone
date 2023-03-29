using Application.Features.GroupTreeContentOperationClaims.Commands.Create;
using Application.Features.GroupTreeContentOperationClaims.Commands.Delete;
using Application.Features.GroupTreeContentOperationClaims.Commands.Update;
using Application.Features.GroupTreeContentOperationClaims.Queries.GetById;
using Application.Features.GroupTreeContentOperationClaims.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupTreeContentOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGroupTreeContentOperationClaimCommand createGroupTreeContentOperationClaimCommand)
    {
        CreatedGroupTreeContentOperationClaimResponse response = await Mediator.Send(createGroupTreeContentOperationClaimCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGroupTreeContentOperationClaimCommand updateGroupTreeContentOperationClaimCommand)
    {
        UpdatedGroupTreeContentOperationClaimResponse response = await Mediator.Send(updateGroupTreeContentOperationClaimCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedGroupTreeContentOperationClaimResponse response = await Mediator.Send(new DeleteGroupTreeContentOperationClaimCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdGroupTreeContentOperationClaimResponse response = await Mediator.Send(new GetByIdGroupTreeContentOperationClaimQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGroupTreeContentOperationClaimQuery getListGroupTreeContentOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGroupTreeContentOperationClaimDto> response = await Mediator.Send(getListGroupTreeContentOperationClaimQuery);
        return Ok(response);
    }
}