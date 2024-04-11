using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResourceList.Contracts.Resource
{
    public record CreateResourceRequest(
        string Title,
        string Description,
        string Url,
        string Type,
        List<string> Tags,
        int Stages
    );
}
