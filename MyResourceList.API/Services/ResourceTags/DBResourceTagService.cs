using MyResourceList.API.Data;
using MyResourceList.API.Models;

namespace MyResourceList.API.Services.ResourceTags
{
    public class DBResourceTagService : IResourceTagService
    {
        protected readonly MyResourceListContext _dbContext;

        public DBResourceTagService(MyResourceListContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CheckResourceTagExists(Guid resourceId, Guid tagId)
        {
            int count = _dbContext.ResourceTags.Where(rt => rt.ResourceId == resourceId && rt.TagId == tagId).Count();
            return count == 1;
        }

        public bool CreateResourceTag(ResourceTag resourcetag)
        {
            throw new NotImplementedException();
        }

        public bool DeleteResourceTag(Guid resourceId, Guid tagId)
        {
            throw new NotImplementedException();
        }

        public List<ResourceTag> GetAllResourceTags()
        {
            throw new NotImplementedException();
        }

        public ResourceTag GetResourceTag(Guid resourceId, Guid tagId)
        {
            throw new NotImplementedException();
        }
    }
}
