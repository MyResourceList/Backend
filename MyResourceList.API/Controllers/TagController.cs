using Microsoft.AspNetCore.Mvc;
using MyResourceList.API.Models;
using MyResourceList.API.Services.Tags;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost()]
        public IActionResult CreateTag(CreateTagRequest request)
        {
            // Mapping DTO to Entity
            Tag tag = new Tag(
                id: Guid.NewGuid(),
                name: request.name,
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now
            );

            // Saving resource to database
            var tag_created = _tagService.CreateTag(tag);
            if (!tag_created)
            {
                return Problem("Error creating tag, please try again.");
            }

            // Mapping Entity to DTO
            var response = new TagResponse(
                Id: tag.Id,
                Name: tag.Name,
                CreatedAt: tag.CreatedAt,
                ModifiedAt: tag.ModifiedAt
            );

            return CreatedAtAction(
                actionName: nameof(GetTag),
                routeValues: new { id = response.Id },
                value: response
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTag(Guid id)
        {
            if (!_tagService.CheckTagExists(id))
            {
                return NotFound();
            }
            var tag = _tagService.GetTag(id);
            return Ok(tag);
        }

        [HttpGet()]
        public IActionResult GetTags()
        {
            var tags = _tagService.GetAllTags();
            return Ok(tags);
        }
    }
}
