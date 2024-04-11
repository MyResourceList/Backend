using MyResourceList.Contracts.Comment;
using MyResourceList.Contracts.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        float Progress,
        List<CommentResponse> Comments,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
