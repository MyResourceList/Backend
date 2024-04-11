using MyResourceList.API.Models;
using MyResourceList.Contracts.Resource;

namespace MyResourceList.API.Services.Resources
{
    public interface IResourceService
    {
        void CreateResource(Resource resource);
        Resource GetResource(Guid id);
        List<Resource> GetAllResources();
    }
}
