using Microsoft.EntityFrameworkCore;
using MyResourceList.API.Data;
using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Tags
{
    public class DBTagService : ITagService
    {
        protected readonly MyResourceListContext _dbContext;

        public DBTagService(MyResourceListContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CheckTagExists(Guid id)
        {
            int count = _dbContext.Tags.Where(r => r.Id == id).Count();
            return count == 1;
        }

        public bool CreateTag(Tag tag)
        {
            if (CheckTagExists(tag.Id))
            {
                return false;
            }
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteTag(Guid id)
        {
            if (!CheckTagExists(id))
            {
                return false;
            }
            _dbContext.Tags.Where(r => r.Id == id).ExecuteDelete();
            _dbContext.SaveChanges();
            return true;
        }

        public List<Tag> GetAllTags()
        {
            return _dbContext.Tags.ToList();
        }

        public Tag GetTag(Guid id)
        {
            return _dbContext.Tags.Where(r => r.Id == id).First();
        }

        public bool UpsertTag(Guid id, Tag new_tag)
        {
            new_tag.Id = id;
            _dbContext.Tags.Update(new_tag);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
