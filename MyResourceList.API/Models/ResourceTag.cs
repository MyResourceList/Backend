namespace MyResourceList.API.Models
{
    public class ResourceTag
    {
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
