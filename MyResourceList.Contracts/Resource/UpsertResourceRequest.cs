using MyResourceList.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResourceList.Contracts.Resource
{
    public record UpsertResourceRequest(
        Guid Id,
        string Title,
        string Description,
        string Url,
        string Type,
        List<string> Tags,
        string Status,
        int Rating,
        float Progress,
        List<CommentResponse> Comments,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
