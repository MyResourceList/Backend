using MyResourceList.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResourceList.Contracts.Resource
{
    public record UpsertResourceRequest(
        string Title,
        string Description,
        string Url,
        string Type,
        List<string> Tags,
        string Status,
        int Rating,
        int Stages,
        float Progress,
        List<string> Comments
    );
}
