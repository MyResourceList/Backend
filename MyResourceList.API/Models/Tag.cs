namespace MyResourceList.API.Models
{
    public class Tag
    {
        public Guid Id { get; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

        public Tag(Guid id, string name, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
    }
}
