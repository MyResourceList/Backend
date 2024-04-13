using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Tags
{
    public interface ITagService
    {
        bool CreateTag(Tag tag);
        Tag GetTag(Guid id);
        List<Tag> GetAllTags();
        bool CheckTagExists(Guid id);
        bool UpsertTag(Guid id, Tag tag);
        bool DeleteTag(Guid id);
    }
}
