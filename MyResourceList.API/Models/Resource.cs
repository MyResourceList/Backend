using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MyResourceList.API.Models
{
    public enum ResourceStates
    {
        [EnumMember(Value = "New")]
        NEW,
        [EnumMember(Value = "Planned")]
        PLANNED,
        [EnumMember(Value = "In Progress")]
        IN_PROGRESS,
        [EnumMember(Value = "Completed")]
        COMPLETED,
        [EnumMember(Value = "To Be Revisited")]
        TO_BE_REVISITED,
        [EnumMember(Value = "Dropped")]
        DROPPED
    }
    public class Resource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public ICollection<ResourceTag> ResourceTags { get; set; }
        [Column(TypeName = "string")]
        public ResourceStates Status { get; set; }
        public int Rating { get; set; }
        public int Stages { get; set; }
        public float Progress { get; set; }
        public List<string> Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        private Resource(Guid id, string title, string description, string url, string type, ResourceStates status, int rating, int stages, float progress, List<string> comments, DateTime createdAt, DateTime modifiedAt)
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

        public Resource(Guid id, string title, string description, string url, string type, ICollection<ResourceTag> resourceTags, ResourceStates status, int rating, int stages, float progress, List<string> comments, DateTime createdAt, DateTime modifiedAt)
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
