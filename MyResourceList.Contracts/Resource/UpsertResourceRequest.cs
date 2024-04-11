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
