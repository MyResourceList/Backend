using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResourceList.Contracts.Comment
{
    public record CommentResponse(
        Guid Id,
        string Text,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
