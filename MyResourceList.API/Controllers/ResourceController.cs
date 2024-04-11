using Microsoft.AspNetCore.Mvc;
using MyResourceList.API.Models;
using MyResourceList.Contracts.Comment;
using MyResourceList.Contracts.Resource;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/resource")]
    public class ResourceController : ControllerBase
    {
        [HttpPost()]
        public IActionResult CreateResource(CreateResourceRequest request)
        {
            // Mapping DTO to Entity
            var tags = new List<Tag>();
            foreach (var tag in request.Tags)
            {
                tags.Add(new Tag(new Guid(), tag, DateTime.Now, DateTime.Now));
            }

            var resource = new Resource(
                new Guid(),
                request.Title,
                request.Description,
                request.Url,
                request.Type,
                tags,
                "New",
                0,
                0,
                [],
                DateTime.Now,
                DateTime.Now
            );

            // TODO : Save resource to database

            // Mapping Entity to DTO
            var response = new ResourceResponse(
                resource.Id,
                resource.Title,
                resource.Description,
                resource.Url,
                resource.Type,
                resource.Tags.Select(tag => new TagResponse(tag.Id, tag.Name, tag.CreatedAt, tag.ModifiedAt)).ToList(),
                resource.Status,
                resource.Rating,
                resource.Progress,
                resource.Comments.Select(comment => new CommentResponse(comment.Id, comment.Text, comment.CreatedAt, comment.ModifiedAt)).ToList(),
                resource.CreatedAt,
                resource.ModifiedAt
            );

            return CreatedAtAction(
                actionName: nameof(GetResource),
                routeValues: new { id = response.Id },
                value: response
            );
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
