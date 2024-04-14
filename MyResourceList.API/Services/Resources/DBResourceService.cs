using Microsoft.EntityFrameworkCore;
using MyResourceList.API.Data;
using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Resources
{
    public class DBResourceService : IResourceService
    {
        protected readonly MyResourceListContext _dbContext;

        public DBResourceService(MyResourceListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckResourceExists(Guid id)
        {
            int count = _dbContext.Resources.Where(r => r.Id == id).Count();
            return count == 1;
        }

        public bool CreateResource(Resource resource)
        {
            if (CheckResourceExists(resource.Id))
            {
                return false;
            }
            _dbContext.Resources.Add(resource);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteResource(Guid id)
        {
            if (!CheckResourceExists(id))
            {
                return false;
            }
            _dbContext.Resources.Where(r => r.Id == id).ExecuteDelete();
            _dbContext.SaveChanges();
            return true;
        }

        public List<Resource> GetAllResources()
        {
            return _dbContext.Resources.ToList();
        }

        public Resource GetResource(Guid id)
        {
            return _dbContext.Resources.Where(r => r.Id == id).First();
        }

        public bool UpsertResource(Guid id, Resource newResource)
        {
            newResource.Id = id;
            if(!CheckResourceExists(id))
            {
                _dbContext.Resources.Add(newResource);
                _dbContext.SaveChanges();
                return true;
            }

            var oldResource = GetResource(id);
            oldResource.Title = newResource.Title;
            oldResource.Description = newResource.Description;
            oldResource.Url = newResource.Url;
            oldResource.Type = newResource.Type;
            oldResource.ResourceTags = newResource.ResourceTags;
            oldResource.Status = newResource.Status;
            oldResource.Rating = newResource.Rating;
            oldResource.Progress = newResource.Progress;
            oldResource.Comments = newResource.Comments;
            oldResource.ModifiedAt = newResource.ModifiedAt;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
