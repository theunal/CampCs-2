using Application.Features.Brands.Commands.CreateBrand;
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
    }
}
