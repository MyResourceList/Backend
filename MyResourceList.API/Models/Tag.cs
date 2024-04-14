namespace MyResourceList.API.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Tag(Guid id, string name, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
    }
}
