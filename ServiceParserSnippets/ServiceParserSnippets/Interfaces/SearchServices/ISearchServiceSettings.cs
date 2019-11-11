
namespace ServiceParserSnippets.Interfaces.SearchServices
{
    public interface ISearchServiceSettings
    {
        string BaseUrl { get; }
        string Page { get; }
        string MainContainerClass { get; }
    }
}
