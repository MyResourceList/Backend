using Microsoft.AspNetCore.Mvc;
using MyResourceList.API.Models;
using MyResourceList.API.Services.Resources;
using MyResourceList.API.Services.Tags;
using MyResourceList.Contracts.Resource;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/resource")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly ITagService _tagService;

        public ResourceController(IResourceService resourceService, ITagService tagService)
        {
            _resourceService = resourceService;
            _tagService = tagService;
        }

        [HttpPost()]
        public IActionResult CreateResource(CreateResourceRequest request)
        {
            // Mapping DTO to Entity

            // Validate Tags
            var tags = new List<ResourceTag>();
            foreach (var tag in request.Tags)
            {
                var tag_exists = _tagService.CheckTagExists(tag);
                if (!tag_exists)
                {
                    return BadRequest($"Tag {tag} does not exist");
                }
                var tag_obj = _tagService.GetTag(tag);
                //tags.Add(new ResourceTag());
            }

            //var resource = new Resource(
            //    id: Guid.NewGuid(),
            //    title: request.Title,
            //    description: request.Description,
            //    url: request.Url,
            //    type: request.Type,
            //    resourcetags: tags,
            //    status: "New",
            //    rating: 0,
            //    stages: request.Stages,
            //    progress: 0,
            //    comments: [],
            //    createdAt: DateTime.Now,
            //    modifiedAt: DateTime.Now
            //);

            //// Save resource to database
            //var is_created = _resourceService.CreateResource(resource);
            //if (!is_created)
            //{
            //    return Problem("Error creating resource, please try again.");
            //}

            //// Mapping Entity to DTO
            //var response = new ResourceResponse(
            //    Id: resource.Id,
            //    Title: resource.Title,
            //    Description: resource.Description,
            //    Url: resource.Url,
            //    Type: resource.Type,
            //    Tags: resource.ResourceTags.Select(resourcetag => new TagResponse(resourcetag.Tag.Id, resourcetag.Tag.Name, resourcetag.Tag.CreatedAt, resourcetag.Tag.ModifiedAt)).ToList(),
            //    Status: resource.Status,
            //    Rating: resource.Rating,
            //    Stages: resource.Stages,
            //    Progress: resource.Progress,
            //    Comments: resource.Comments,
            //    CreatedAt: resource.CreatedAt,
            //    ModifiedAt: resource.ModifiedAt
            //);

            //return CreatedAtAction(
            //    actionName: nameof(GetResource),
            //    routeValues: new { id = response.Id },
            //    value: response
            //);
            return Ok();
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
            var existed = _resourceService.CheckResourceExists(id);

            // Mapping DTO to Entity

            // Validate Tags
            var tags = new List<ResourceTag>();
            foreach (var tag in request.Tags)
            {
                var tag_exists = _tagService.CheckTagExists(tag);
                if (!tag_exists)
                {
                    return BadRequest($"Tag {tag} does not exist");
                }
                //tags.Add(new ResourceTag());
            }

            //var resource = new Resource(
            //    id: id,
            //    title: request.Title,
            //    description: request.Description,
            //    url: request.Url,
            //    type: request.Type,
            //    resourcetags: tags,
            //    status: request.Status,
            //    rating: request.Rating,
            //    stages: request.Stages,
            //    progress: request.Progress,
            //    comments: request.Comments,
            //    createdAt: DateTime.Now,
            //    modifiedAt: DateTime.Now
            //);

            //// Save resource to database
            //var is_upserted = _resourceService.UpsertResource(id, resource);
            //if (!is_upserted)
            //{
            //    return Problem("Error upserting resource, please try again.");
            //}

            //// Fetch Updated/New Resource
            //var new_resource = _resourceService.GetResource(id);

            //// Mapping Entity to DTO
            //var response = new ResourceResponse(
            //    Id: new_resource.Id,
            //    Title: new_resource.Title,
            //    Description: new_resource.Description,
            //    Url: new_resource.Url,
            //    Type: new_resource.Type,
            //    Tags: new_resource.ResourceTags.Select(resourcetag => new TagResponse(resourcetag.Tag.Id, resourcetag.Tag.Name, resourcetag.Tag.CreatedAt, resourcetag.Tag.ModifiedAt)).ToList(),
            //    Status: new_resource.Status,
            //    Rating: new_resource.Rating,
            //    Stages: new_resource.Stages,
            //    Progress: new_resource.Progress,
            //    Comments: new_resource.Comments,
            //    CreatedAt: new_resource.CreatedAt,
            //    ModifiedAt: new_resource.ModifiedAt
            //);

            //if (!existed)
            //{
            //    return CreatedAtAction(
            //        actionName: nameof(GetResource),
            //        routeValues: new { id = response.Id },
            //        value: response
            //    );
            //}
            //else
            //{
            //    return Ok(response);
            //}
            return Ok();
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
