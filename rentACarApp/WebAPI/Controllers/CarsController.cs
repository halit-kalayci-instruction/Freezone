using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListByDynamic;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Dynamic;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
    {
        CreatedCarResponse response = await Mediator.Send(createCarCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
    {
        UpdatedCarResponse response = await Mediator.Send(updateCarCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCarResponse response = await Mediator.Send(new DeleteCarCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCarResponse response = await Mediator.Send(new GetByIdCarQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCarQuery getListCarQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCarDto> response = await Mediator.Send(getListCarQuery);
        return Ok(response);
    }

    //  {
    //  "sort": [{"field":"id","dir":"desc"}],
    //  "filter": {
    //    "field": "Kilometer",
    //    "operator": "gt",
    //    "value": "6500",
    //    "logic":"or",
    //    "filters":[ {"field":"ModelYear", "operator":"eq", "value":"2022"} ]
    //  }
    //}

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic? dynamic=null)
    {
        GetListCarByDynamicQuery query = new() { PageRequest= pageRequest, Dynamic = dynamic };
        GetListResponse<GetListCarByDynamicDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}