using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResourceList.Contracts.Tag
{
    public record TagResponse(
        Guid Id,
        string Name,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );
}
