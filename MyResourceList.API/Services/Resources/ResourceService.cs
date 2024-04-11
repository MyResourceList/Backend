using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Resources
{
    public class ResourceService : IResourceService
    {
        private readonly Dictionary<Guid, Resource> _db = new();
        public void CreateResource(Resource resource)
        {
            _db.Add(resource.Id, resource);
        }

        public Resource GetResource(Guid id)
        {
            return _db[id];
        }

        public List<Resource> GetAllResources()
        {
            return _db.Values.ToList();
        }
    }
}
