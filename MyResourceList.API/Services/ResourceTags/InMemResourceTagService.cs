using MyResourceList.API.Models;

namespace MyResourceList.API.Services.ResourceTags
{
    public class InMemResourceTagService : IResourceTagService
    {
        private readonly Dictionary<Tuple<Guid, Guid>, ResourceTag> _db = new();

        public bool CheckResourceTagExists(Guid resourceId, Guid tagId)
        {
            return _db.ContainsKey(new Tuple<Guid, Guid>(resourceId, tagId));
        }

        public bool CreateResourceTag(ResourceTag resourcetag)
        {
            if(CheckResourceTagExists(resourcetag.ResourceId, resourcetag.TagId))
            {
                return false;
            }
            _db[new Tuple<Guid, Guid>(resourcetag.ResourceId, resourcetag.TagId)] = resourcetag;
            return true;
        }

        public bool DeleteResourceTag(Guid resourceId, Guid tagId)
        {
            throw new NotImplementedException();
        }

        public List<ResourceTag> GetAllResourceTags()
        {
            return _db.Values.ToList();
        }

        public ResourceTag GetResourceTag(Guid resourceId, Guid tagId)
        {
            return _db[new Tuple<Guid, Guid>(resourceId, tagId)];
        }
    }
}
