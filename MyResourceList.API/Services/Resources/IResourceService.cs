using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Resources
{
    public interface IResourceService
    {
        void CreateResource(Resource resource);
        Resource GetResource(Guid id);
        List<Resource> GetAllResources();
        bool CheckResourceExists(Guid id);
        void UpsertResource(Guid id, Resource new_resource);
        bool DeleteResource(Guid id);
    }
}
