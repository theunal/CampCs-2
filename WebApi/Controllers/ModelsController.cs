using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] GetListModelQueryRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {   
            var request = new GetListModelByDynamicQueryRequest { PageRequest = pageRequest, Dynamic = dynamic };
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
