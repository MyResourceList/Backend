using MyResourceList.API.Models;
using MyResourceList.Contracts.Resource;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.API.Mappers
{
    public class ResourceMapper
    {
        public static Resource MapCreateResourceDTOToResource(CreateResourceRequest request)
        {
            var resource = new Resource(
                id: Guid.NewGuid(),
                title: request.Title,
                description: request.Description,
                url: request.Url,
                type: request.Type,
                resourceTags: [],
                status: ResourceStates.NEW,
                rating: 0,
                stages: request.Stages,
                progress: 0,
                comments: [],
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now
            );

            return resource;
        }

        public static Resource MapUpsertResourceDTOToResource(UpsertResourceRequest request)
        {
            if (!Enum.TryParse(request.Status, out ResourceStates resourceState))
            {
                throw new Exception($"Could not parse {request.Status} into a valid state");
            }
            var resource = new Resource(
                id: new Guid(),
                title: request.Title,
                description: request.Description,
                url: request.Url,
                type: request.Type,
                resourceTags: [],
                status: resourceState,
                rating: request.Rating,
                stages: request.Stages,
                progress: request.Progress,
                comments: request.Comments,
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now
            );
            return resource;
        }

        public static ResourceResponse MapResourceToResourceDTO(Resource resource)
        {
            var response = new ResourceResponse(
                Id: resource.Id,
                Title: resource.Title,
                Description: resource.Description,
                Url: resource.Url,
                Type: resource.Type,
                Tags: resource.ResourceTags.Select(resourcetag => new TagResponse(resourcetag.Tag.Id, resourcetag.Tag.Name, resourcetag.Tag.CreatedAt, resourcetag.Tag.ModifiedAt)).ToList(),
                Status: resource.Status.ToString(),
                Rating: resource.Rating,
                Stages: resource.Stages,
                Progress: resource.Progress,
                Comments: resource.Comments,
                CreatedAt: resource.CreatedAt,
                ModifiedAt: resource.ModifiedAt
            );

            return response;
        }
    }
}
