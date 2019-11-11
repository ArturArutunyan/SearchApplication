
using ServiceParser.Interfaces.SearchServices;

namespace ServiceParserSnippets.Entities
{
    public class Snippet : ISnippet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
