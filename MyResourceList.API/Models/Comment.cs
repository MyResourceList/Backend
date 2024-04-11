namespace MyResourceList.API.Models
{
    public class Comment
    {
        public Guid Id { get; }
        public string Text { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

        public Comment(Guid id, string text, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Text = text;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
    }
}
