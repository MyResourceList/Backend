using MyResourceList.API.Models;

namespace MyResourceList.API.Services.ResourceTags
{
    public interface IResourceTagService
    {
        bool CreateResourceTag(ResourceTag resourcetag);
        ResourceTag GetResourceTag(Guid resourceId, Guid tagId);
        List<ResourceTag> GetAllResourceTags();
        bool CheckResourceTagExists(Guid resourceId, Guid tagId);
        bool DeleteResourceTag(Guid resourceId, Guid tagId);
    }
}
