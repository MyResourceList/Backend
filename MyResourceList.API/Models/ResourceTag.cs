namespace MyResourceList.API.Models
{
    public class ResourceTag
    {
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        private ResourceTag(Guid resourceId, Guid tagId)
        {
            ResourceId = resourceId;
            Resource = null!;
            TagId = tagId;
            Tag = null!;
        }
        public ResourceTag(Guid resourceId, Resource resource, Guid tagId, Tag tag)
        {
            ResourceId = resourceId;
            Resource = resource;
            TagId = tagId;
            Tag = tag;
        }
    }
}
