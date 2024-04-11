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
