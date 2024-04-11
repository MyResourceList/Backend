namespace MyResourceList.Contracts.Comment
{
    public record CommentResponse(
        Guid Id,
        string Text,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
