namespace MyResourceList.Contracts.Tag
{
    public record TagResponse(
        Guid Id,
        string Name,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
