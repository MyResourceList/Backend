namespace MyResourceList.API.Models
{
    public class Resource
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }
        public string Type { get; }
        public List<Tag> Tags { get; }
        public string Status { get; }
        public int Rating { get; }
        public int Stages { get; }
        public float Progress { get; }
        public List<string> Comments { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

        public Resource(Guid id, string title, string description, string url, string type, List<Tag> tags, string status, int rating, int stages, float progress, List<string> comments, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Url = url;
            Type = type;
            Tags = tags;
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
