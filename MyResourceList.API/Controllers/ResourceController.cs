using Microsoft.AspNetCore.Mvc;
using MyResourceList.API.Mappers;
using MyResourceList.API.Models;
using MyResourceList.API.Services.Resources;
using MyResourceList.API.Services.ResourceTags;
using MyResourceList.API.Services.Tags;
using MyResourceList.Contracts.Resource;

namespace MyResourceList.API.Controllers
{
    [ApiController]
    [Route("api/resource")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly ITagService _tagService;
        private readonly IResourceTagService _resourceTagService;

        public ResourceController(IResourceService resourceService, ITagService tagService, IResourceTagService resourceTagService)
        {
            _resourceService = resourceService;
            _tagService = tagService;
            _resourceTagService = resourceTagService;
        }

        [HttpPost()]
        public IActionResult CreateResource(CreateResourceRequest request)
        {
            // Mapping DTO to Entity
            var resource = ResourceMapper.MapCreateResourceDTOToResource(request);

            // Validate Tags
            var resourceTags = new List<ResourceTag>();
            foreach (var tag in request.Tags)
            {
                var tagExists = _tagService.CheckTagExists(tag);
                if (!tagExists)
                {
                    return BadRequest($"Tag {tag} does not exist");
                }
                var tagObj = _tagService.GetTag(tag);
                resourceTags.Add(
                    new ResourceTag(
                        resourceId: resource.Id,
                        resource: resource,
                        tagId: tagObj.Id,
                        tag: tagObj
                    )
                );
            }

            // Save data to DB
            _resourceService.CreateResource(resource);
            foreach (var resourceTag in resourceTags)
            {
                _resourceTagService.CreateResourceTag(resourceTag);
            }
            resource.ResourceTags = resourceTags;
            _resourceService.UpsertResource(resource.Id, resource);

            // Mapping Entity to DTO
            var response = ResourceMapper.MapResourceToResourceDTO(resource);
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
            var response = new List<ResourceResponse>();
            foreach (var resource in resources)
            {
                response.Add(ResourceMapper.MapResourceToResourceDTO(resource));
            }
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetResource(Guid id)
        {
            if (_resourceService.CheckResourceExists(id) == false)
            {
                return NotFound();
            }
            var resource = _resourceService.GetResource(id);
            var response = ResourceMapper.MapResourceToResourceDTO(resource);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertResource(Guid id, UpsertResourceRequest request)
        {
            // Check if resource already exists
            var existed = _resourceService.CheckResourceExists(id);

            // Mapping DTO to Entity
            var resource = ResourceMapper.MapUpsertResourceDTOToResource(request);

            // Validate Tags
            var resourceTags = new List<ResourceTag>();
            foreach (var tag in request.Tags)
            {
                var tagExists = _tagService.CheckTagExists(tag);
                if (!tagExists)
                {
                    return BadRequest($"Tag {tag} does not exist");
                }
                var tagObj = _tagService.GetTag(tag);
                resourceTags.Add(
                    new ResourceTag(
                        resourceId: resource.Id,
                        resource: resource,
                        tagId: tagObj.Id,
                        tag: tagObj
                    )
                );
            }

            // Save resource to database
            foreach (var resourceTag in resourceTags)
            {
                _resourceTagService.CreateResourceTag(resourceTag);
            }
            resource.ResourceTags = resourceTags;
            _resourceService.UpsertResource(id, resource);

            // Fetch Updated/New Resource
            var new_resource = _resourceService.GetResource(id);

            // Mapping Entity to DTO
            var response = ResourceMapper.MapResourceToResourceDTO(new_resource);

            if (!existed)
            {
                return CreatedAtAction(
                    actionName: nameof(GetResource),
                    routeValues: new { id = response.Id },
                    value: response
                );
            }
            else
            {
                return Ok(response);
            }
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
