using Application.Features.TitleOperationClaims.Commands.Create;
using Application.Features.TitleOperationClaims.Commands.Delete;
using Application.Features.TitleOperationClaims.Commands.Update;
using Application.Features.TitleOperationClaims.Queries.GetById;
using Application.Features.TitleOperationClaims.Queries.GetList;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTitleOperationClaimCommand createTitleOperationClaimCommand)
    {
        CreatedTitleOperationClaimResponse response = await Mediator.Send(createTitleOperationClaimCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTitleOperationClaimCommand updateTitleOperationClaimCommand)
    {
        UpdatedTitleOperationClaimResponse response = await Mediator.Send(updateTitleOperationClaimCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTitleOperationClaimResponse response = await Mediator.Send(new DeleteTitleOperationClaimCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTitleOperationClaimResponse response = await Mediator.Send(new GetByIdTitleOperationClaimQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleOperationClaimQuery getListTitleOperationClaimQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTitleOperationClaimDto> response = await Mediator.Send(getListTitleOperationClaimQuery);
        return Ok(response);
    }
}