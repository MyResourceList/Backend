namespace MyResourceList.API.Models
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public ICollection<ResourceTag> ResourceTags { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }
        public int Stages { get; set; }
        public float Progress { get; set; }
        public List<string> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        private Resource(Guid id, string title, string description, string url, string type, string status, int rating, int stages, float progress, List<string> comments, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Url = url;
            Type = type;
            ResourceTags = new List<ResourceTag>();
            Status = status;
            Rating = rating;
            Stages = stages;
            Progress = progress;
            Comments = comments;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }

        public Resource(Guid id, string title, string description, string url, string type, ICollection<ResourceTag> resourceTags, string status, int rating, int stages, float progress, List<string> comments, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Url = url;
            Type = type;
            ResourceTags = resourceTags;
            Status = status;
            Rating = rating;
            Stages = stages;
            Progress = progress;
            Comments = comments;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
    }
}
