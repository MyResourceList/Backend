using Microsoft.AspNetCore.Mvc;
using MyResourceList.Contracts.Resource;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourcesController : ControllerBase
    {
        [HttpPost()]
        public IActionResult CreateResource(CreateResourceRequest request)
        {
            return Ok(request);
        }

        [HttpGet()]
        public IActionResult GetResources()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetResource(Guid id)
        {
            return Ok(id);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertResource(Guid id, CreateResourceRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteResource(Guid id)
        {
            return Ok(id);
        }
    }
}
