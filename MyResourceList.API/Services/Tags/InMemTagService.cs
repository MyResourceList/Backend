using MyResourceList.API.Models;

namespace MyResourceList.API.Services.Tags
{
    public class InMemTagService : ITagService
    {
        private readonly Dictionary<Guid, Tag> _db = new();
        public bool CheckTagExists(Guid id)
        {
            return _db.ContainsKey(id);
        }

        public bool CreateTag(Tag tag)
        {
            if (CheckTagExists(tag.Id))
            {
                return false;
            }
            _db.Add(tag.Id, tag);
            return true;
        }

        public bool DeleteTag(Guid id)
        {
            if (!CheckTagExists(id))
            {
                return false;
            }
            _db.Remove(id);
            return true;
        }

        public List<Tag> GetAllTags()
        {
            return _db.Values.ToList();
        }

        public Tag GetTag(Guid id)
        {
            return _db[id];
        }

        public bool UpsertTag(Guid id, Tag new_tag)
        {
            if (!CheckTagExists(id))
            {
                _db[id] = new_tag;
                return true;
            }

            var old_tag = _db[id];
            if (old_tag == null)
            {
                return false;
            }

            _db[id] = new Tag(
                id: old_tag.Id,
                name: new_tag.Name,
                createdAt: old_tag.CreatedAt,
                modifiedAt: new_tag.ModifiedAt
            );
            return true;
        }
    }
}
