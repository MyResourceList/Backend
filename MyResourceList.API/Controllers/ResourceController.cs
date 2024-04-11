using Microsoft.AspNetCore.Mvc;
using MyResourceList.API.Models;
using MyResourceList.API.Services.Resources;
using MyResourceList.Contracts.Comment;
using MyResourceList.Contracts.Resource;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/resource")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost()]
        public IActionResult CreateResource(CreateResourceRequest request)
        {
            // Mapping DTO to Entity
            var tags = new List<Tag>();
            foreach (var tag in request.Tags)
            {
                tags.Add(
                    new Tag(
                        id: Guid.NewGuid(),
                        name: tag,
                        createdAt: DateTime.Now,
                        modifiedAt: DateTime.Now
                    )
                );
            }

            var resource = new Resource(
                id: Guid.NewGuid(),
                title: request.Title,
                description: request.Description,
                url: request.Url,
                type: request.Type,
                tags: tags,
                status: "New",
                rating: 0,
                stages: request.Stages,
                progress: 0,
                comments: [],
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now
            );

            // Save resource to database
            _resourceService.CreateResource(resource);

            // Mapping Entity to DTO
            var response = new ResourceResponse(
                Id: resource.Id,
                Title: resource.Title,
                Description: resource.Description,
                Url: resource.Url,
                Type: resource.Type,
                Tags: resource.Tags.Select(tag => new TagResponse(tag.Id, tag.Name, tag.CreatedAt, tag.ModifiedAt)).ToList(),
                Status: resource.Status,
                Rating: resource.Rating,
                Stages: resource.Stages,
                Progress: resource.Progress,
                Comments: resource.Comments.Select(comment => new CommentResponse(comment.Id, comment.Text, comment.CreatedAt, comment.ModifiedAt)).ToList(),
                CreatedAt: resource.CreatedAt,
                ModifiedAt: resource.ModifiedAt
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
            var resources = _resourceService.GetAllResources();
            return Ok(resources);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetResource(Guid id)
        {
            if (_resourceService.CheckResourceExists(id) == false)
            {
                return NotFound();
            }
            var resource = _resourceService.GetResource(id);
            return Ok(resource);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertResource(Guid id, UpsertResourceRequest request)
        {
            if (_resourceService.CheckResourceExists(id) == false)
            {
                return NotFound();
            }
            // Mapping DTO to Entity
            var tags = new List<Tag>();
            foreach (var tag in request.Tags)
            {
                tags.Add(
                    new Tag(
                        id: Guid.NewGuid(),
                        name: tag,
                        createdAt: DateTime.Now,
                        modifiedAt: DateTime.Now
                    )
                );
            }

            var comments = new List<Comment>();
            foreach (var comment in request.Comments)
            {
                comments.Add(
                    new Comment(
                        id: Guid.NewGuid(),
                        text: comment,
                        createdAt: DateTime.Now,
                        modifiedAt: DateTime.Now
                    )
                );
            }

            var resource = new Resource(
                id: id,
                title: request.Title,
                description: request.Description,
                url: request.Url,
                type: request.Type,
                tags: tags,
                status: request.Status,
                rating: request.Rating,
                stages: request.Stages,
                progress: request.Progress,
                comments: comments,
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now
            );

            // Save resource to database
            _resourceService.UpdateResource(id, resource);

            // Mapping Entity to DTO
            var response = new ResourceResponse(
                Id: resource.Id,
                Title: resource.Title,
                Description: resource.Description,
                Url: resource.Url,
                Type: resource.Type,
                Tags: resource.Tags.Select(tag => new TagResponse(tag.Id, tag.Name, tag.CreatedAt, tag.ModifiedAt)).ToList(),
                Status: resource.Status,
                Rating: resource.Rating,
                Stages: resource.Stages,
                Progress: resource.Progress,
                Comments: resource.Comments.Select(comment => new CommentResponse(comment.Id, comment.Text, comment.CreatedAt, comment.ModifiedAt)).ToList(),
                CreatedAt: resource.CreatedAt,
                ModifiedAt: resource.ModifiedAt
            );

            return CreatedAtAction(
                actionName: nameof(GetResource),
                routeValues: new { id = response.Id },
                value: response
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteResource(Guid id)
        {
            if (_resourceService.CheckResourceExists(id) == false)
            {
                return NotFound();
            }
            _resourceService.DeleteResource(id);
            return NoContent();
        }
    }
}
