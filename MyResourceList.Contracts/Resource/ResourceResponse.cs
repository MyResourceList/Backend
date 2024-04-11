using MyResourceList.Contracts.Comment;
using MyResourceList.Contracts.Tag;

namespace MyResourceList.Contracts.Resource
{
    public record ResourceResponse(
        Guid Id,
        string Title,
        string Description,
        string Url,
        string Type,
        List<TagResponse> Tags,
        string Status,
        int Rating,
        int Stages,
        float Progress,
        List<CommentResponse> Comments,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
