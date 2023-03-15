using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) 
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);

            return Created("",response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            GetByIdBrandResponse response = await Mediator.Send(new GetByIdBrandQuery {Id=id });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateCarCommand)
        {
            UpdatedBrandResponse response = await Mediator.Send(updateCarCommand);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletedBrandResponse response = await Mediator.Send(new DeleteBrandCommand { Id = id });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GetAllBrandQuery getListBrandQuery = new();
            IEnumerable<GetAllBrandDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }
    }
}
