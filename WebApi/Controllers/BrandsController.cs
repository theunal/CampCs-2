using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Queries.GetBrandById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandCommandRequest request)
        {
            var result = await Mediator.Send(request);
            return Created("", result);
        }


        [HttpGet("getBrandList")]
        public async Task<IActionResult> GetBrandList([FromQuery] PageRequest request)
        {
            var getListBrandRequest = new GetListBrandQueryRequest() { PageRequest = request };
            var result = await Mediator.Send(getListBrandRequest);
            return Ok(result);
        }

        [HttpGet("getBrandById")]
        public async Task<IActionResult> GetBrandById([FromQuery] GetBrandByIdRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
